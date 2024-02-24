using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.DTOs
{
    public class StoreDto
    {
        public string  storeName { get; set; }
        public string storeDescription { get; set; }
        public string storeCategory { get; set; }
        public string City { get; set; }

        public StoreDto()
        {
        }

        //public StoreDto(string storeId, string storeName, int storeRefNumber)
        //{
        //    _storeId = storeId;
        //    _storeName = storeName;
        //    _storeReferenceNumber = storeRefNumber;
        //}
    }
    public class CreateStoreDto
    {
        [Required(ErrorMessage = "Name Required")]
        [MinLength(2, ErrorMessage = "Company Name canot not be less than 2 char")]
        [MaxLength(150, ErrorMessage = "Namme too Longr")]
        public string storeName { get; set; }
    }
    public class UpdateStoreDto
    {
        public Guid storeGuid { get; set; }
        [Required]
        public string storeName { get; set; }
        public bool storeIsEnabled { get; set; }
        public bool storeIsDeleted { get; set; }
    }
    //public class UserDTO
    //{
    //}
}
