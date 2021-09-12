using System.Collections.Generic;

namespace CA.Application.Services.Product.Queries.GetProductDetailsForAdmin
{
    public class ProductDetailsForAdminDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public List<ProductDetailsFeatureDto> Features { get; set; }
        public List<ProductDetailsImagesDto> Images { get; set; }
    }
}