using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CA.Application.Services.Roles.Queries;
using CA.Application.Services.Users.Commands.ChangeUserStatus;
using CA.Application.Services.Users.Commands.EditUser;
using CA.Application.Services.Users.Commands.RegisterUser;
using CA.Application.Services.Users.Commands.RemoveUser;
using CA.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IChangeUserStatusService _changeUserStatusService;
        private readonly IEditUserService _editUserService;

        public UsersController(
            IGetUsersService getUsersService
            ,IGetRolesService getRolesService
            ,IRegisterUserService registerUserService
            ,IRemoveUserService removeUserService
            ,IChangeUserStatusService changeUserStatusService
            ,IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _changeUserStatusService = changeUserStatusService;
            _editUserService = editUserService;
        }

        public IActionResult Index(string searchkey , int page = 1)
        {
            var model = _getUsersService.Execute(new RequestGetUsersDto
            {
                SearchKey = searchkey,
                Page = page
            });

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email =Email,
                FullName = FullName,
                Roles = new List<RoleInRegisterUserDto>()
                {
                    new RoleInRegisterUserDto()
                    {
                        Id= RoleId
                    }
                },
                Password = Password,
                RePassword = RePassword,
            });
            return Json(result);
        }


        [HttpPost]
        public IActionResult Delete(long userid)
        {
            return new JsonResult(_removeUserService.Execute(userid));
        }


        [HttpPost]
        public IActionResult ChangeStatus(long userId)
        {
            return new JsonResult(_changeUserStatusService.Execute(userId));
        }


        public IActionResult Edit(long userId,string fullName)
        {
            return new JsonResult(_editUserService.Execute(new RequestEditUserDto
            {
                UserId = userId,
                Fullname = fullName
            }));
        }
    }
}
