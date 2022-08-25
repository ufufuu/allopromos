using allopromo.Admin.Models.Dto;
using allopromo.Admin.Models.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, UserDto>()
                .ForMember(x => x.UserName, map => map.MapFrom(m => m.UserName))
                .ForMember(x => x.UserPwd, map => map.MapFrom(m => m.PasswordHash));
            CreateMap<UserDto, LoginViewModel>()
                .ForMember(x => x.UserName, map => map.MapFrom(m => m.UserName))
                .ForMember(x => x.PasswordHash, map => map.MapFrom(m => m.UserPwd));
        }
    }
}
