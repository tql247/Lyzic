using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Lyzic.Repositories;


namespace Lyzic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Trả về trang chủ
        public IActionResult Index()
        {
            var JWToken = HttpContext.Session.GetString("JWToken");
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            try
            {
                if (identity != null)
                {
                    var account = AccountRes.Profile(1);
                    return View(account);
                }
                return View();
            }
            catch (System.Exception)
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
