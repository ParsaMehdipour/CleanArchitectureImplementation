using CA.Application.Interfaces.FacadePatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacadePattern _productFacade;

        public ProductsController(IProductFacadePattern productFacade)
        {
            _productFacade = productFacade;
        }
        public IActionResult Index(string searchKey, long? catId,int page=1)
        {
            return View(_productFacade.GetProductsForSiteService.Execute(searchKey,catId,page).Data);
        }


        public IActionResult Details(long Id)
        {
            return View(_productFacade.GetProductDetailsForSiteService.Execute(Id).Data);
        }
    }
}
