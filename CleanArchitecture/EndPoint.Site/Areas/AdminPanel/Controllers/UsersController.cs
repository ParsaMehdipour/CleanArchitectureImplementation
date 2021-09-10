using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Application.Services.Roles.Queries;
using CA.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;

        public UsersController(IGetUsersService getUsersService,IGetRolesService getRolesService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
        }

        public IActionResult Index(RequestGetUsersDto request)
        {
            var model = _getUsersService.Execute(request);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }
    }
}
