
using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class StoreCategoryProfile : Profile
    {
        public StoreCategoryProfile()
        {
            //this.CreateMap<StoreCategory, StoreCategoryDto>().ForMember<string>((Expression<Func<StoreCategoryDto, string>>)(x => x.DepartmentName), (Action<IMemberConfigurationExpression<StoreCategory, StoreCategoryDto, string>>)(m => m.Ignore()));
            //this.CreateMap<StoreCategoryDto, StoreCategory>().ForMember<Guid>((Expression<Func<StoreCategory, Guid>>)(dest => dest.storeCategoryId), (Action<IMemberConfigurationExpression<StoreCategoryDto, StoreCategory, Guid>>)(m => m.Ignore())).ForMember<string>((Expression<Func<StoreCategory, string>>)(dest => dest.storeCategoryName), (Action<IMemberConfigurationExpression<StoreCategoryDto, StoreCategory, string>>)(m => m.Ignore())).ForMember<DateTime>((Expression<Func<StoreCategory, DateTime>>)(dest => dest.created), (Action<IMemberConfigurationExpression<StoreCategoryDto, StoreCategory, DateTime>>)(m => m.Ignore())).ForMember<DateTime?>((Expression<Func<StoreCategory, DateTime?>>)(dest => dest.expires), (Action<IMemberConfigurationExpression<StoreCategoryDto, StoreCategory, DateTime?>>)(m => m.Ignore())).ForMember<bool>((Expression<Func<StoreCategory, bool>>)(dest => dest.active), (Action<IMemberConfigurationExpression<StoreCategoryDto, StoreCategory, bool>>)(m => m.Ignore())).ForMember<ICollection<Store>>((Expression<Func<StoreCategory, ICollection<Store>>>)(dest => dest.Stores), (Action<IMemberConfigurationExpression<StoreCategoryDto, StoreCategory, ICollection<Store>>>)(m => m.Ignore())).ForPath<string>((Expression<Func<StoreCategory, string>>)(dest => dest.Department.departmentName), (Action<IPathConfigurationExpression<StoreCategoryDto, StoreCategory, string>>)(m => m.MapFrom<string>((Expression<Func<StoreCategoryDto, string>>)(src => src.DepartmentName))));
        }
    }
}
