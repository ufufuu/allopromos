namespace allopromo.Core.Application.Dto
{
    public class ProductDto
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public virtual StoreDto productStoreId { get; set; }

        public int productStatus { get; set; }
    }
    public class MakeDto
    {
        public int makeId { get; set; }
        public string makeTitle { get; set; }
        public string makeLogo { get; set; }
    }
}

