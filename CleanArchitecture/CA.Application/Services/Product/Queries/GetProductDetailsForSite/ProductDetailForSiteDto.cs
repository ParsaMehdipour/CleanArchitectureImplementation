using System.Collections.Generic;

namespace CA.Application.Services.Product.Queries.GetProductDetailsForSite
{
    public class ProductDetailsForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDetailsForSiteFeaturesDto> Features { get; set; }
    }
}