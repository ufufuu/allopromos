using allopromo.Api.DTOs;
using allopromo.Api.Infrastructure.Abstract;
using allopromo.Api.Infrastructure.Mapping.Profiles;
using allopromo.Api.Infrastructure.Logging;
using allopromo.Api.Infrastructure.Mapping;
using allopromo.Api.Validators;
using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Helpers;
using allopromo.Core.Infrastructure.Abstract;
using allopromo.Core.Interfaces;
using allopromo.Core.Model;
using allopromo.Core.Services;
using allopromo.Core.Services.Base;
using allopromo.Core.Services.Media;
using allopromo.Infrastructure.Data;
using allopromo.Infrastructure.Repositories;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Retry;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;

#nullable enable
namespace allopromo.Api
{
    public class Startup
    {
        public readonly
#nullable disable
    string MyAllowSpecificOrigins = "myAllowSpecificOrigin";

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc((Action<MvcOptions>)(options => options.EnableEndpointRouting = false));
            this.Configuration.GetSection("JwtSettings");
            this.Configuration.GetSection("Jwt").Get<AppSettings>();
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["Jwt:Secret"]);
            services.AddDbContext<ApplicationDbContext>((Action<DbContextOptionsBuilder>)(
                options => options.UseSqlServer(Configuration.GetConnectionString("dockerConnectionProd0"))));

            services.AddIdentity<ApplicationUser, IdentityRole>((Action<IdentityOptions>)(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultTokenProviders();
            services.AddAuthentication("Bearer").AddJwtBearer((Action<JwtBearerOptions>)(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = this.Configuration["Jwt:ValidIssuer"],
                    ValidAudience = this.Configuration["Jwt:ValidAudience"],
                    IssuerSigningKey = (SecurityKey)new SymmetricSecurityKey(key),
                    RequireExpirationTime = false
                };
            }));
            services.AddAuthorization((Action<AuthorizationOptions>)(options =>
            {
                options.AddPolicy("MerchantsOnly", (Action<AuthorizationPolicyBuilder>)(policy => policy.RequireRole("Merchants")));
                options.AddPolicy("ClientsOnly", (Action<AuthorizationPolicyBuilder>)(policy => policy.RequireRole("Clients")));
            }));
            IMapper mapper = new MapperConfiguration((Action<IMapperConfigurationExpression>)(mc =>
            {
                mc.AddProfile<UserProfile>();
                mc.AddProfile<StoreProfile>();
                mc.AddProfile<ProductProfile>();
                mc.AddProfile<StoreCategoryProfile>();
                mc.AddProfile<CityProfile>();
                mc.AddProfile<ProductCategoryProfile>();

                //mc.ValidateInlineMaps = new bool?(false);
            })).CreateMapper();
            services.AddSingleton<IMapper>(mapper);
            /// <summary>
            /// Add MediatR
            /// </summary>
            //services.AddMediatR(typeof(CreateCommandHandler));
            /// <summary>
            /// Add AutoMapper
            /// </summary>
            AutoMapperConfig.Configure();
            services.AddAutoMapper(typeof(Program));
            services.AddDistributedMemoryCache();
            services.AddSession((Action<SessionOptions>)(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10.0);
                options.Cookie.HttpOnly = true;
            }));
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddControllers();
            SwaggerGenServiceCollectionExtensions.AddSwaggerGen(services, (Action<SwaggerGenOptions>)(c =>
            {
                SwaggerGenOptionsExtensions.SwaggerDoc(c, "v1", new OpenApiInfo()
                {
                    Title = "allopromo API",
                    Version = "v1"
                });
                SwaggerGenOptionsExtensions.AddSecurityDefinition(c, "Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                SwaggerGenOptions swaggerGenOptions = c;
                SwaggerGenOptionsExtensions.AddSecurityRequirement(swaggerGenOptions, new OpenApiSecurityRequirement()
        {
          {
            new OpenApiSecurityScheme()
            {
              Reference = new OpenApiReference()
              {
                Type = new ReferenceType?(ReferenceType.SecurityScheme),
                Id = "Bearer"
              }
            },
            (IList<string>) Array.Empty<string>()
          }
        });
            }));
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IBaseService<DepartmentDto>, BaseService<DepartmentDto>>();
            services.AddScoped<IRepository<DepartmentDto>, TRepository<DepartmentDto>>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<INotifyService, NotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IStoreService, StoreService>();
            
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IImageUploadService, ImageUploadService>();
            services.AddScoped<IMediaService, ImgurMediaService>();

            services.AddScoped<IRepository<Store>, TRepository<Store>>();
            services.AddScoped<IRepository<StoreCategory>, TRepository<StoreCategory>>();
            services.AddScoped<IRepository<Product>, TRepository<Product>>();
            services.AddScoped<IRepository<ProductCategory>, TRepository<ProductCategory>>();
            services.AddScoped<IRepository<City>, TRepository<City>>();
            services.AddScoped<IRepository<Country>, TRepository<Country>>();
            services.AddScoped<IRepository<Department>, TRepository<Department>>();

            //services.AddScoped<IValidator<CreateUserDto>, CreateUserValidator>();

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<EmailConfiguration>(this.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddSingleton<IEmailConfiguration, EmailConfiguration>();
            services.AddSignalRCore();
            services.AddSignalR();
            /*
            ServiceCollectionExtensions.AddMediatR(services, (Action<MediatRServiceConfiguration>)
                (cfg => cfg.RegisterServicesFromAssemblies(new Assembly[1]
                {
                    typeof (Program).Assembly
                })));
            */

            services.AddCors((Action<CorsOptions>)(policyBuilder => policyBuilder.AddDefaultPolicy((Action<CorsPolicyBuilder>)(policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader()))));
            FluentEmailServiceCollectionExtensions.AddFluentEmail(services, "test-email@allopromo.test", "");
            services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>((IAsyncPolicy<HttpResponseMessage>)AsyncRetryTResultSyntax.WaitAndRetryAsync<HttpResponseMessage>(Policy.HandleResult<HttpResponseMessage>((Func<HttpResponseMessage, bool>)(r => !r.IsSuccessStatusCode)), 3, (Func<int, TimeSpan>)(retryAttemps => TimeSpan.FromSeconds((double)retryAttemps))));
            HttpClient httpClient = new HttpClient();
            services.AddSingleton<AsyncRetryPolicy>((Func<IServiceProvider, AsyncRetryPolicy>)(x => AsyncRetrySyntax.WaitAndRetryAsync(Policy.Handle<Exception>(), 3, (Func<int, TimeSpan>)(retryCount => TimeSpan.FromMilliseconds((double)(500 * retryCount))), (Action<Exception, TimeSpan, int, Context>)((result, timeSpan, retryCount, context) => Console.WriteLine(string.Format("begin {0} retry {1} ", (object)retryCount, (object)context.CorrelationId) + string.Format("with {0} seconds of delays", (object)timeSpan.TotalSeconds))))));
            //services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SwaggerBuilderExtensions.UseSwagger(app, (Action<SwaggerOptions>)null);
                SwaggerUIBuilderExtensions.UseSwaggerUI(app, (Action<SwaggerUIOptions>)null);
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors((Action<CorsPolicyBuilder>)(options => options.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((Func<string, bool>)(host => true)).AllowCredentials()));
            app.UseCors("CORSPolicy");
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseEndpoints((Action<IEndpointRouteBuilder>)(endpoint => endpoint.MapControllers()));
            SwaggerBuilderExtensions.UseSwagger(app, (Action<SwaggerOptions>)null);
            SwaggerUIBuilderExtensions.UseSwaggerUI(app, (Action<SwaggerUIOptions>)(c =>
            {
                SwaggerUIOptionsExtensions.DefaultModelExpandDepth(c, -1);
                SwaggerUIOptionsExtensions.SwaggerEndpoint(c, "/swagger/v1/swagger.json", "My-- API V1");
            }));
            app.UseCors((Action<CorsPolicyBuilder>)(options => options.AllowAnyMethod()
			.WithOrigins("http://localhost:44306")
			.AllowAnyHeader()
			.SetIsOriginAllowed((Func<string, bool>)(host => true)).AllowCredentials()));
            app.UseMvc();
        }
    }
}
