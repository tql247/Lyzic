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

        public IActionResult Index()
        {
            var JWToken = HttpContext.Session.GetString("JWToken");
            // Console.WriteLine(JWToken);

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            Console.WriteLine(identity);
            try
            {
                if (identity != null)
                {
                    Console.WriteLine("AccountID");
                    Console.WriteLine(identity.FindFirst("UserName").Value);
                    Console.WriteLine(identity.FindFirst("AccountID").Value);
                }
                var account = AccountRes.Profile(1);
                return View(account);
            }
            catch (System.Exception)
            {
                return View();
            }
            // if (identity != null)
            // {
            //     Console.WriteLine("AccountID");
            //     Console.WriteLine(identity.FindFirst("UserName").Value);
            //     Console.WriteLine(identity.FindFirst("AccountID").Value);
            // }
            // return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
