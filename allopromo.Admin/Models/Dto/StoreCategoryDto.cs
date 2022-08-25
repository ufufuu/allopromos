using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace allopromo.Admin.Models.Dto
{
    public class StoreCategoryDto
    {
        public int storeCategoryId { get; set; }
        public string storeCategoryName { get; set; }
        public bool isParent { get; set; }
        public string categoryThumb { get; set; }

        //public static explicit operator StoreCategoryDto(HttpContent v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
