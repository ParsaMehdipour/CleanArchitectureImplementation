using CA.Application.Interfaces.Contexts;
using CA.Application.Interfaces.FacadePatterns;
using CA.Application.Services.Category.Commands.AddNewCategory;
using CA.Application.Services.Product.Commands.AddNewProduct;
using CA.Application.Services.Product.Queries.GetProductDetailsForAdmin;
using CA.Application.Services.Product.Queries.GetProductsForAdmin;
using CA.Application.Services.Product.Queries.GetProductsForSite;
using Microsoft.AspNetCore.Hosting;

namespace CA.Application.Services.Product.FacadePattern
{
    public class ProductFacadePattern : IProductFacadePattern
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductFacadePattern(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IAddNewProductService _addNewProductService;

        public IAddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService ??= new AddNewProductService(_context, _environment);
            }
        }

        private IGetProductsForAdminService _getProductsForAdminService;

        public IGetProductsForAdminService GetProductsForAdminService
        {
            get
            {
                return _getProductsForAdminService ??= new GetProductsForAdminService(_context);
            }
        }

        private IGetProductDetailsForAdminService _getProductDetailsForAdminService;

        public IGetProductDetailsForAdminService GetProductDetailsForAdminService
        {
            get
            {
                return _getProductDetailsForAdminService ??= new GetProductDetailsForAdminService(_context);
            }
        }

        private IGetProductsForSiteService _getProductsForSiteService;

        public IGetProductsForSiteService GetProductsForSiteService
        {
            get
            {
                return _getProductsForSiteService ??= new GetProductsForSiteService(_context);
            }
        }
    }
}
