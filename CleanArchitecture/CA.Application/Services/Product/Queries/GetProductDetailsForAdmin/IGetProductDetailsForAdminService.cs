using CA.Common.Dto;

namespace CA.Application.Services.Product.Queries.GetProductDetailsForAdmin
{
    public interface IGetProductDetailsForAdminService
    {
        ResultDto<ProductDetailsForAdminDto> Execute(long Id);

    }
}
