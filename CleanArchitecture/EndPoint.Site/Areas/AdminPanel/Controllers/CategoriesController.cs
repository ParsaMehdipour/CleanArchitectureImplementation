using CA.Application.Interfaces.FacadePatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class CategoriesController : Controller
    {

        private readonly ICategoryFacadePattern _categoryFacade;

        public CategoriesController(ICategoryFacadePattern categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }


        public IActionResult Index(long? id)
        {
            return View(_categoryFacade.GetCategoriesService.Execute(id).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? id)
        {
            ViewBag.parentId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId, string Name)
        {
            var result = _categoryFacade.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }
    }
}
