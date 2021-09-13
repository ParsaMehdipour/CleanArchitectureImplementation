using CA.Common.Dto;

namespace CA.Application.Services.Product.Queries.GetProductsForSite
{
    public interface IGetProductsForSiteService
    {
        ResultDto<ResultProductsForSiteDto> Execute(long? catId,int Page);
    }
}
