
//using allopromo.Api.ViewModel.ViewModels;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.Infrastructure.Mapper.Profiles
{

    public static class AutoMapperCollectionExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if(services == null)
            {
                throw new ArgumentException(nameof(services));
            }
            //var config = new AutoMapperConfig().Configure();
            //Bservices.AddSingleton<IMapper>(sp => config.CreateMapper());
        }
    }
}


//Mapper.Initialize(x =>
//{
//    x.AddProfile<MappingProfile>();
//});
//Mapper.Configuration.AssertConfigurationIsValid(); //}