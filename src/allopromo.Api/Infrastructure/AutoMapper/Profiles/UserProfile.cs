using allopromo.Api.ViewModel.ViewModels;
using allopromo.Core.Application.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<IdentityUser, UserDto>()
            .ForMember(dest => dest.userEmail, mo => mo.Ignore())
            .ForMember(x => x.userPhoneNumber, phone => phone.Ignore())
            .ForMember(x => x.userRoleName, role => role.Ignore())
            .ForMember(x => x.userPassword, p => p.Ignore());
            CreateMap<IdentityUser, RegisterViewModel>();

            CreateMap<UserDto, IdentityUser>();
            //.ForMember(dest => dest.Email, mo => mo.Ignore());
            CreateMap<RegisterViewModel, IdentityUser>();
        }
    }
}
