//using allopromoex;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                //.AddJsonFile("Ocelot.json")
                .Build();
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                //Log.CloseAndFlush();
            }
            CreateWebHostBuilder(args).Build().Run();//or BelowF
            //Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONNEMENT1", "Production");
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        /*public static HostBuilder CreateHostBuilder(string args)
        {
            return Host.CreateHostBuilder(HostBuilder)
        }*/
        //? What does this Do ? What are CreateDefaulBuilder - CreateHostBuilder ?
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //().UseUrl("http:localhost:4000");
                })
            //Configure Serilog
            .UseSerilog((hostingContext, loggerConfiguration) =>
            loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)); 
    }
}
