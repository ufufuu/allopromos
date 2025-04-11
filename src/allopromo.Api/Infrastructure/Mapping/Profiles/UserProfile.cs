
using allopromo.Api.DTOs;
using allopromo.Api.ViewModel.ViewModels;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDto>()
            .ForMember(src => src.Password, mo => mo.Ignore())
            .ForMember(x => x.PhoneNumber, pn => pn.Ignore())
            .ForMember(x => x.roleName, role => role.Ignore())
            .ForMember(x => x.firstName, p => p.Ignore());
            CreateMap<IdentityUser, RegisterViewModel>();

            CreateMap<UserDto, ApplicationUser>();
            //.ForMember(dest => dest.Email, mo => mo.Ignore());
            CreateMap<RegisterViewModel, IdentityUser>();
        }

        /*
        public UserProfile()
        {
        .CreateMap<ApplicationUser, UserDto>()
                .ForMember<string>((Expression<Func<UserDto, string>>)(src => src.Password), (Action<IMemberConfigurationExpression<ApplicationUser, UserDto, string>>)(dest => dest.MapFrom<string>((Expression<Func<ApplicationUser, string>>)(y => y.PasswordHash))))
                .ForMember<string>((Expression<Func<UserDto, string>>)(src => src.roleName), (Action<IMemberConfigurationExpression<ApplicationUser, UserDto, string>>)(dest => dest.MapFrom<string>((Expression<Func<ApplicationUser, string>>)(y => y.UserRoles.FirstOrDefault<ApplicationRole>().roleName))))
                .ForMember<string>((Expression<Func<UserDto, string>>)(src => src.firstName), (Action<IMemberConfigurationExpression<ApplicationUser, UserDto, string>>)(dest => dest.MapFrom<string>((Expression<Func<ApplicationUser, string>>)(y => y.firstName))))
                .ForMember<string>((Expression<Func<UserDto, string>>)(src => src.lastName), (Action<IMemberConfigurationExpression<ApplicationUser, UserDto, string>>)(dest => dest.MapFrom<string>((Expression<Func<ApplicationUser, string>>)(y => y.lastName))));
            this.CreateMap<UserDto, ApplicationUser>().ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.PasswordHash), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(dest => dest.MapFrom<string>((Expression<Func<UserDto, string>>)(mo => mo.Password))))
                .ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.Id), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(mo => mo.Ignore()))
                .ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.NormalizedUserName), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(mo => mo.Ignore()))
                .ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.NormalizedEmail), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(mo => mo.Ignore()))
                .ForMember<bool>((Expression<Func<ApplicationUser, bool>>)(src => src.EmailConfirmed), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, bool>>)(mo => mo.Ignore())).ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.SecurityStamp), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(mo => mo.Ignore()))
                .ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.firstName), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(dest => dest.MapFrom<string>((Expression<Func<UserDto, string>>)(y => y.firstName))))
                .ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.lastName), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(dest => dest.MapFrom<string>((Expression<Func<UserDto, string>>)(y => y.lastName))))
                .ForMember<IList<ApplicationRole>>((Expression<Func<ApplicationUser, IList<ApplicationRole>>>)(src => src.UserRoles), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, IList<ApplicationRole>>>)(dest => dest.MapFrom<IList<RoleDto>>((Expression<Func<UserDto, IList<RoleDto>>>)(y => y.UserRoles))))
                .ForMember<string>((Expression<Func<ApplicationUser, string>>)(src => src.ConcurrencyStamp), (Action<IMemberConfigurationExpression<UserDto, ApplicationUser, string>>)(mo => mo.Ignore()));
        }
        */
    }
}
