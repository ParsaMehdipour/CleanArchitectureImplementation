using CA.Common.Dto;

namespace CA.Application.Services.Product.Queries.GetProductsForSite
{
    public interface IGetProductsForSiteService
    {
        ResultDto<ResultProductsForSiteDto> Execute(string searchKey,long? catId,int Page);
    }
}
