
using allopromo.Api.Infrastructure.Mapping.Profiles;
using allopromo.Api.ViewModel.ViewModels;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<StoreProfile>();
                cfg.AddProfile<ProductCategoryProfile>();
            });
            config.AssertConfigurationIsValid();   
            var mapper = config.CreateMapper();
            return config;
        }
    }
}
