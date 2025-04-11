using allopromo.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace allopromo.Api.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }

        public string categoryName { get; set; }

        public string Description { get; set; }

        public float productPrice { get; set; }

        public IList<IFormFile> ProductImages { get; set; }
    }


    public class ProductUpdateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string categoryName { get; set; }

        public IList<ProductPictureDto> productImages { get; set; }

        [Required]
        [MaxLength(30)]
        public string? productImg { get; set; }

        public IFormFile? productImageFiles { get; set; }
    }

}


