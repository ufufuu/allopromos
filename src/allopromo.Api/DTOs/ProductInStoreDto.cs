using allopromo.Core.Entities;

namespace allopromo.Api.DTOs
{
    public class ProductInStoreDto
    {
        public string Name { get; set; }

        public string categoryName { get; set; }

        public string Description { get; set; }

        public float productPrice { get; set; }

//        public IList<IFormFile> ProductImages { get; set; }
    }
}

