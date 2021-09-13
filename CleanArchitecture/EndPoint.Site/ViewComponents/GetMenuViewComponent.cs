using CA.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenuViewComponent : ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItemService;

        public GetMenuViewComponent(IGetMenuItemService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_getMenuItemService.Execute().Data.MenuItemDtos);
        }
    }
}
