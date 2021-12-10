using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Lyzic.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IWebHostEnvironment _environment;
        public AccountController(ILogger<AccountController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }

        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            _logger.LogInformation("Index Action");


            return "I'm there";
        }

        // GET: AccountController/Details
        public ActionResult Profile(int id)
        {

            var JWToken = HttpContext.Session.GetString("JWToken");
            // Console.WriteLine(JWToken);

            // var identity = HttpContext.User.Identity as ClaimsIdentity;
            // if (identity != null)
            // {
            //     Console.WriteLine("AccountID");
            //     Console.WriteLine(identity.FindFirst("AccountID").Value);
            // }
            // lay ra thong tin AccountID tu jwt
            var account = AccountRes.Profile(1);
            return View(account);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

    }
}