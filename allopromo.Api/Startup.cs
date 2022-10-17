using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using allopromo.Core.Abstract;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Identity;
using allopromo.Model.Validation;

using allopromo.Api.Infrastructure;
//using allopromoInfrastructure.Abstract;

using allopromo.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using allopromo.Infrastructure.Helpers.Authentication;
using allopromo.Core.Infrastructure.Abstract;

//using Owin;
//using Microsoft.Owin;
using Microsoft.AspNetCore.ResponseCompression;
using System.Linq;
using System;
using allopromo.Core.Application;
using allopromo.Infrastructure.Repositories;
using allopromo.Core.Domain;
using allopromo.Infrastructure.Abstract;
using allopromo.Core.Entities;
//using allopromo.Api.Model;
using allopromo.Api;
using allopromo.Core.Services;
using allopromo.Api.Infrastructure.Abstract;
using allopromo.Api.Infrastructure.Logging;
using Microsoft.Extensions.Hosting;
//using Ocelot.Middleware;
//using Ocelot.DependencyInjection;

//using allopromo.Api.Services.Factory;
//using allopromo.Core.Application.Interface;
//using allopromo.Core.Services;
//using allopromo.Infrastructure.Helpers.Authentication;
//[assembly:OwinStartup(typeof(allopromo.Startup))]
namespace allopromo
{
    public class  Startup
    {
        public readonly string MyAllowSpecificOrigins = "myAllowSpecificOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Register(services, connString)

            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultDevConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            /*
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Test";
            })*/
                /*.AddScheme<ValidateHashAuthenticationSchemeOptions, ValidateHashAuthenticationHandler>
                ("Test", null);*/
            //By Jwt Bearer Adding from Below|

            .AddJwtBearer(token =>
            {
                token.SaveToken = true;
                token.RequireHttpsMetadata = false;
                token.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey=true,
                    RequireExpirationTime=true,
                    ValidateLifetime=true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew=TimeSpan.Zero,                                    
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
                //Events
                token.Events = new JwtBearerEvents
                {
                    //OnChallenge= async ctx =>
                    //{
                        // get the app calling
                        //get EF
                        //can Read
                        //check if 
                        // Add claim
                    //}
                };

            });
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDevConnection"))
            );
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddOptions();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<INotifyService, EmailNotificationService>();



            //2 lines below vs 2 above ? or Addtransient vs addScoped ?
            //services.AddTransient<IStoreService, StoreService>();
            //services.AddTransient<INotificationService, NotificationService>();

            //services.AddScoped<IRepository<T>, Repository<T>> where T:class();
            //services.AddScoped<IUserRepository, UserRepository>();
            //Action<Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions> c= null;


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "my API", Version = "v1" });
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<INotifyService, EmailNotificationService>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRepository<tStore>, TRepository<tStore>>();

            //services.AddScoped<IRepository, TRepository>();

            //services.AddScoped <Core.Abstract.IStoreRepository,
            //Infrastructure.Repositories.StoreRepository>();

            services.AddScoped(sp => ActivatorUtilities.CreateInstance<UserManager<ApplicationUser>>(sp));
            //services.AddScoped<ILoggerManager, LoggerManager>();
            //?Instead of <ApplicationUser>>
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<EmailConfiguration>
                (Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddSingleton<IEmailConfiguration, EmailConfiguration>();
            //services.AddScoped(sp => ActivatorUtilities.CreateInstance<UserManager<tUser>>(sp)); //?Instead of <ApplicationUser>>
            services.AddCors(
                            x => x.AddPolicy("AllowOrigin", 
                                //options => options.AllowAnyOrigin()
                            builder =>
                            {
                                builder
                                    .AllowAnyOrigin()
                                    //.AllowCredentials()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                            }
                ));
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" });
            });



            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultScheme = "Test";
            //})
            //    .AddScheme<ValidateHashAuthenticationSchemeOptions, ValidateHashAuthenticationHandler>("Test", null);
            //Adding E-mail Services




            services.AddFluentEmail("test-email@allopromo.test");
            //services.AddOcelot();
        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {


            /*
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => {
                    await context.Response.WriteAsync("Hello From ASP.NET Core Web API");
                });
            });
            */

            
            if (env.IsDevelopment()) //if(env.IsProduction() || ens.IsStaging() || env.IsEnvironnement("Staging_2"))
            {
                //app.UserExceptionHandler("/Home/Error-local-development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/error");
                //Or Below ?
                app.UseHsts();
            }
            //app.ConfigureExceptionHandler(logger);// OR Below 
            //app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseOcelot();

            //app.UseMvc();
            app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader()
            .SetIsOriginAllowed((host) => true).AllowCredentials() //vs alloAnyOrigin
            );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();


                //Utilisez l’intergiciel decompression deréponseen haut dela
                //configuration du pipeline detraitement.
                //Entreles points determinaison pour les contrôleurs et lesecours 
                //côtéclient,ajoutez un point de
                //terminaison pour le Hub

                ///endpoints.MapHub<ChatHub>("/chathub");

                endpoints.MapFallbackToFile("index.html");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            AutoMapperConfiguration.Initialize();
            /*
            app.UseMvc();
            app.UseCors(options =>options.AllowAnyMethod().AllowAnyHeader()
            .SetIsOriginAllowed((host)=>true).AllowCredentials()
            );
            //Register MiddleWare for the Signal R Middleware("/signalrr", new HubConfiguration(
            app.UseCors("AllowCors");
            app.UseSignalR(routes =>
            {
                routes.MapHub<allopromoServers.Hubs.Chat>("/chathub");
            });
            app.UseMvc();
            /*
             app.Map("signalr", map=>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJSONP = true,
                };
                //map.RunSignalR(hubConfiguration);
            }); 
            */
            //HANDLING GLOBALLY EXCEPTIONS
            //app.UseMiddleware(typeof(ExceptionHandling));
            //app.UseMiddleware<ExceptionHandler>();
        }
    }
}
/*//https://www.infoworld.com/article/3545304/how-to-handle-404-errors-in-aspnet-core-mvc.html
 * app.Use(async (context, next) =>
    {
    await next();
    if (context.Response.StatusCode == 404)
       {
         context.Request.Path = "/Home";
         await next();
       }
    });
*/
// order creates delivery when is it delivery , not if picking up
// sotre COntroller Unauthorized , redirect to User to Login , if Unauthorized send to User Auth
// if Authorized ?
/*
 * Functional Document Specification : Test Cases 
 */
/*
 * 1 -- Account Asp.net Identity + fb+ tiwtter !
 * 2-- create store scenario <- account login and register
 * business Login for Account registration
 * 3- Test Unit for bl account Registration             3-- Code Versionning    4
 * 4 - TDD / Buzz Fizz
 * Reapeat !
 * 
 */
/*Adapter -> Facade ! */
// NET CORE vs .NET ?
//https://markheath.net/post/asserting-events-with-nunit
//https://pluralsight.pxf.io/c/1192349/424552/7490?u=www%2Epluralsight%2Ecom%2Fcourses%2Fazure-container-instances-getting-started

// What is Proxy Class ? - Factory Pattern - Factory Methods patterns | Strategy |
//Luke Lowery
//Top Best 14 libraries:
// MediatR: mediator pattern X
//Serilog X
//Hangfire X
//Fluentemail
//LazyCache: thread safe wrapper for in-memory caching - requesting an item from the cache - or add the item to cache
//Dapper: EF access being too slow - Run raw SQL and getting object mapping wiht Dapper
//Miniprofiler X
//LinqKit
//FluentMigrator or DBUp
//SVHelper
//Hashids
//Humanizer: turning dates, numbers , enums to more huma readable strings 
//Bogus
//Automapper X - FluentValidation X - Autofac X

/* From User Stories to Unit testing cases to making Passe the tests -> TDD
 */

// Top 10 C# Librairies: 
//Autofac - AutoMapper - FLuentValidation - Hangfire - MediatR - Swagger(Swashbuckle) - OpenAPI -
//Serilog - xUnit - Moq - FluentAssertions - AutoFixture - MiniProfiler - EPPlus - 
//1-> jwt 2-> sending msg 3-> roles based access 4->

// 
/* store service business layer: if it existe, date time, is
 * 
 * project libre
 * Gant roject ?
 * 
 * Ioc through DIP --- other means ???? XXXXXX ----- AutoFac ---AutoMapper ----Onion---vs LAyered Architeture --- return good Store *******
 * Planning 
 * 
 *  Delegates - Actions  - Functions  - using lambda expr - anonymous types
 *  Testing thoses 
 *  
 *  auth - filitering - idetity server 4 - jwt - filtering - caching - 
 *  collection generic & non generic 
 *  
 *  Push Notification - SignalR - Identiy Server 4 ? ---> Dapper vs E.F !
 *  Tasking <Asynchronous>
 */

/*
 * https://enlabsoftware.com/development/how-to-build-and-deploy-a-three-layer-architecture-application-with-c-sharp-net-in-practice.html
 *
 */

/* systemes Embarques 
 *
 */