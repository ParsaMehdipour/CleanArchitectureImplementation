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
        public IActionResult Index(long? id,int page=1)
        {
            return View(_productFacade.GetProductsForSiteService.Execute(id,page).Data);
        }


        //public IActionResult Detail(long Id)
        //{
        //    //return View(_productFacade.GetProductsDetailForSiteService.Execute(Id).Data);
        //}
    }
}
