using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Controllers
{
    public class AccountController:Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return File("~/defalt.html", "text/html");
        }
        [Route("forbidden")]
        public IActionResult Forbidden()
        {
            return File("~/forbidden.html", "text/html");
        }
    }

}
