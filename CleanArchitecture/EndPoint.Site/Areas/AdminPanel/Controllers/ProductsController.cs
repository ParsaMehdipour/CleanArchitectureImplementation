using System.Collections.Generic;
using CA.Application.Interfaces.FacadePatterns;
using CA.Application.Services.Product.Commands.AddNewProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductsController : Controller
    {

        private readonly IProductFacadePattern _productFacade;
        private readonly ICategoryFacadePattern _categoryFacade;

        public ProductsController(IProductFacadePattern productFacade,ICategoryFacadePattern categoryFacade)
        {
            _productFacade = productFacade;
            _categoryFacade = categoryFacade;
        }
        public IActionResult Index(int Page = 1, int PageSize = 20)
        {
            return View(_productFacade.GetProductsForAdminService.Execute(Page,PageSize).Data);
        }

        public IActionResult Details(long Id)
        {
            return View(_productFacade.GetProductDetailsForAdminService.Execute(Id).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_categoryFacade.GetAllCategoriesService.Execute().Data,"Id" , "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request, List<AddNewProductFeaturesDto> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            foreach (var file in Request.Form.Files)
            {
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_productFacade.AddNewProductService.Execute(request));
        }
    }
}
