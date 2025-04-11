using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            //this.CreateMap<City, CityDto>().ForMember(dto => dto.cityName), (Action<IMemberConfigurationExpression<City, CityDto, string>>)(y => y.MapFrom<string>((Expression<Func<City, string>>)(city => city.cityName))));
            //this.CreateMap<CityDto, City>().ForMember<int>((Expression<Func<City, int>>)(city => city.cityId), (Action<IMemberConfigurationExpression<CityDto, City, int>>)(m => m.Ignore())).ForMember<Country>((Expression<Func<City, Country>>)(city => city.cityCountry), (Action<IMemberConfigurationExpression<CityDto, City, Country>>)(m => m.Ignore()));
        }
    }
}
