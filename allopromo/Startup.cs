using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allopromoDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using allopromoServiceLayer.Abstract;
using allopromoServiceLayer.Model;
using allopromoDataAccess.Abstract;
using allopromoDataAccess.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
namespace allopromo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>

            services.AddDbContext<allopromoDataAccess.Data.AppDbContext>(options =>
                 options.UseSqlServer(

                     //("DefaultConnection")));

                     Configuration.GetConnectionString("DefaultConnection")));

            //services.AddRazorPages();

            // Prevent Unable to Register Service for type....UserManager<ApplicationUser> whiel trying to activate ..
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //forget 2 below Lines
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddOptions();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Here to Return 404 
            /*
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => {
                    await context.Response.WriteAsync("Hello From ASP.NET Core Web API");
                });
            });
            */
            //Below to return Customized Message 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
