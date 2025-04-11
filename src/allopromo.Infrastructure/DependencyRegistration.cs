using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Infrastructure
{
    public class DependencyRegistration 
    {
        public void Register(IServiceCollection services, string connectString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectString)
             );
            services.AddDbContext<AppDbContext>(options =>
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
             );
        }
    }
}


//Onion Architecture =>

/*
 * When Not Wanting to User Repository+ Unit of Work, Abstract DbContext
 * and createan interface which would Reside in Domain Layer whereas the Implementation
 * for It resides in infrastructure Layer+ in startup: 
 * service.AddScoped<I DbContext>(provider.GetService<AppDnbContext>());
 *
 */

