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
            CreateMap<City, CityDto>()
                .ForMember(dto => dto.cityName, y => y.MapFrom(city => city.cityName));


            CreateMap<CityDto, City>()
                .ForMember (city => city.cityId, m => m.Ignore())
                .ForMember (city => city.cityCountry, m => m.Ignore());
        }
    }
}

/*
 * 
 * this.CreateMap<City, CityDto>().ForMember<string>((Expression<Func<CityDto, string>>) (dto => dto.cityName), (Action<IMemberConfigurationExpression<City, CityDto, string>>) (y => y.MapFrom<string>((Expression<Func<City, string>>) (city => city.cityName))));
      this.CreateMap<CityDto, City>().ForMember<int>((Expression<Func<City, int>>) (city => city.cityId), (Action<IMemberConfigurationExpression<CityDto, City, int>>) (m => m.Ignore())).ForMember<Country>((Expression<Func<City, Country>>) (city => city.cityCountry), (Action<IMemberConfigurationExpression<CityDto, City, Country>>) (m => m.Ignore()));
    }
  }
*/