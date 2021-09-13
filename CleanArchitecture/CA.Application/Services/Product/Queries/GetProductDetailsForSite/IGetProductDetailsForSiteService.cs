using CA.Common.Dto;

namespace CA.Application.Services.Product.Queries.GetProductDetailsForSite
{
    public interface IGetProductDetailsForSiteService
    {
        ResultDto<ProductDetailsForSiteDto> Execute(long Id);
    }
}
