using allopromo.Admin.Models.Dto;
using allopromo.Admin.Models.ViewModel;
using allopromo.Admin.Profiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}

//
//Singleton Pattern !

//2. Nestung Class within another ?> why Doing ?