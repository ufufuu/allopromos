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
        public IList<IFormFile> productImages { get; set; }
    }

    public class CreateProductDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string categoryName { get; set; }
        public string Description { get; set; }
        public float productPrice { get; set; }
        public IList<IFormFile> productImages { get; set; }

        //public IList<ProductPictureDto> productImages { get; set; }
        //public string? productImg { get; set; }
        //public IFormFile? productImageFiles { get; set; }
    }
    public class ProductUpdateDto:CreateProductDto
    {
    }
}


