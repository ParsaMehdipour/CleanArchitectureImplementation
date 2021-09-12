using CA.Application.Services.Category.Commands.AddNewCategory;
using CA.Application.Services.Product.Commands.AddNewProduct;
using CA.Application.Services.Product.Queries.GetProductDetailsForAdmin;
using CA.Application.Services.Product.Queries.GetProductsForAdmin;

namespace CA.Application.Interfaces.FacadePatterns
{
    public interface IProductFacadePattern
    {
        public AddNewProductService AddNewProductService { get; }

        /// <summary>
        /// دریافت لیست محصولات برای پنل مدیریت
        /// </summary>
        public IGetProductsForAdminService GetProductsForAdminService { get; }

        public IGetProductDetailsForAdminService GetProductDetailsForAdminService { get; }
    }
}
