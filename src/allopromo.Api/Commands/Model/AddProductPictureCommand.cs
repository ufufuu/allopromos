//using allopromo.Api.DTOs

using allopromo.Core.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Commands.Model
{
    public class AddProductPictureCommand:IRequest<bool>
    {
        public ProductDto Product { get; set; }


        //public ProductPictureDtp productPictureDto { get; set; }
    }
}
