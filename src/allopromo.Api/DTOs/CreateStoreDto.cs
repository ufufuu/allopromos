using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

#nullable disable
namespace allopromo.Api.DTOs
{
    public class CreateStoreDto
    {
        [Required(ErrorMessage = "Name Required")]
        [MinLength(2, ErrorMessage = "Company Name canot not be less than 2 char")]
        [MaxLength(150, ErrorMessage = "Namme too Longr")]
        public string StoreName { get; set; }
        public string CategoryName { get; set; }
        public string storeIsResto { get; set; }
        public string City { get; set; }
        public string StoreDescription { get; set; }
        public IList<IFormFile> storeFiles { get; set; }
        public string ProprioName { get; set; }
    }
}
