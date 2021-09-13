using CA.Application.Services.Category.Queries.GetCategories;
using CA.Application.Services.Common.Queries.GetCategoriesForSearch;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        private readonly IGetCategoriesForSearchService _getCategoriesForSearchService;

        public SearchViewComponent(IGetCategoriesForSearchService getCategoriesForSearchService)
        {
            _getCategoriesForSearchService = getCategoriesForSearchService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_getCategoriesForSearchService.Execute().Data.CategoryDtos);
        }
    }
}
