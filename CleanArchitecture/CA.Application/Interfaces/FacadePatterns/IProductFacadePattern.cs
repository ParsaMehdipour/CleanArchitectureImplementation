using CA.Application.Services.Category.Commands.AddNewCategory;
using CA.Application.Services.Product.Commands.AddNewProduct;

namespace CA.Application.Interfaces.FacadePatterns
{
    public interface IProductFacadePattern
    {
        public AddNewProductService AddNewProductService { get;}
    }
}
