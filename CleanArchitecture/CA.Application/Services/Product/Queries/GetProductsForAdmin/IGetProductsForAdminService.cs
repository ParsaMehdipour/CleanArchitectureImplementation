using CA.Common.Dto;

namespace CA.Application.Services.Product.Queries.GetProductsForAdmin
{
    public interface IGetProductsForAdminService
    {
        ResultDto<ResultProductsForAdminDto> Execute(int Page = 1, int PageSize = 20);
    }
}
