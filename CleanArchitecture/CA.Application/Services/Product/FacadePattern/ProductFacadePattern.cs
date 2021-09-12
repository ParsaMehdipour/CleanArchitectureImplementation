using CA.Application.Interfaces.Contexts;
using CA.Application.Interfaces.FacadePatterns;
using CA.Application.Services.Category.Commands.AddNewCategory;
using CA.Application.Services.Product.Commands.AddNewProduct;
using Microsoft.AspNetCore.Hosting;

namespace CA.Application.Services.Product.FacadePattern
{
    public class ProductFacadePattern : IProductFacadePattern
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductFacadePattern(IDataBaseContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private AddNewProductService _addNewProductService;

        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService ??= new AddNewProductService(_context, _environment);
            }
        }

    }
}
