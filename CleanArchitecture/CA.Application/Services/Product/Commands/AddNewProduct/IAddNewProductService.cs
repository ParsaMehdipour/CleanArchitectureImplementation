using CA.Common.Dto;

namespace CA.Application.Services.Product.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(RequestAddNewProductDto request);
    }
}
