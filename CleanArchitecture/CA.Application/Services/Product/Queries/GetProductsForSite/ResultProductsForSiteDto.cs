using System.Collections.Generic;

namespace CA.Application.Services.Product.Queries.GetProductsForSite
{
    public class ResultProductsForSiteDto
    {

        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }
}