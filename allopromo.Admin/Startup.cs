using allopromo.Admin.Models;
using allopromo.Admin.Models.Dto;
using allopromo.Admin.Models.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace allopromo.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration{get;}
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            //var autoMapperConfig = new MapperConfiguration//(new MappingProfile());
            //(
            //    mc => mc.AddProfile(new MappingProfile())
            //);
            //IMapper mapper = autoMapperConfig.CreateMapper();

            //services.AddSingleton(mapper);

            //AutoMapperConfiguration.Configure();

            #region Adding Resiliency Policy
            services.AddHttpClient("allo-promo")
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());
            #endregion
            //#region Adding FluentValidation -- preprocessor directive ? expected 
            services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
            services.AddScoped<IValidator<StoreCategoryDto>, StoreCategoryDtoValidator>();
            //#endregion
            services.AddMvc(options => // For Multiple Area Routing 
            {
                options.EnableEndpointRouting = false;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. 
                //You may want to change this for production scenarios, 
                //see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "Manage",
                //    pattern: "manage/{controller=allopromo.Admin.Areas.Manage.Controllers.Home}/{action=Index}");

                //endpoints.MapControllerRoute(
                //    name: "manageAreaRoute",
                //    pattern: "{area=exists}/{controller}/{action}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "Manage",
                //    template: "manage/{controller=allopromo.Admin.Areas.Manage.Controllers.Home}/{action=Index} "
                //        );
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}");
            });
        }
        #region Define Polly Resilience
        private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions

                .HandleTransientHttpError()
                .OrResult(msg=>msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

           // return HttpPolicyExtensions
           //// HttpRequestException, 5XX and 408  
           //.HandleTransientHttpError()
           //// 404  
           //.OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
           //// Retry two times after delay  
           //.WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
        #endregion
    }
}
