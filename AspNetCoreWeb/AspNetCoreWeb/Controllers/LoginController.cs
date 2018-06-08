using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWeb.UserApp;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWeb.Controllers
{
    public class LoginController : Controller
    {
        private IUserAppService _userAppService;
        public LoginController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = _userAppService.CheckUser("admin", "1");
            return View();
        }
    }
}