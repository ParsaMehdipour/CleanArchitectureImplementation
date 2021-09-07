using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.AdminPanel.Controllers
{
    public class UsersController : Controller
    {
        [Area("AdminPanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
