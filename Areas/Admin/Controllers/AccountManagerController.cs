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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Lyzic.Controllers
{
    
    public class AccountManagerController : Controller
    {
        private readonly ILogger<AccountManagerController> _logger;
        private readonly IWebHostEnvironment _environment;
        public AccountManagerController(ILogger<AccountManagerController> logger, IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            var JWToken = HttpContext.Session.GetString("JWToken");
            // Console.WriteLine(JWToken);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                Console.WriteLine("RoleName");
                Console.WriteLine(identity.FindFirst("RoleName").Value);
            }

            var listaccount = AccountManagerRes.GetAll();
            return View(listaccount);
        }
        
        // GET: AccountManagerController/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        // GET: AccountManagerController/Create
        public ActionResult Create(AccountManager account)
        {
            AccountManagerRes.Insert(account);

            return RedirectToAction(nameof(Index));
        }
        

        // // GET: AccountManagerController/Details
        [Authorize]
        public ActionResult Details(int id)
        {
            var account = AccountManagerRes.Detail(id);
            return View(account);
        }

        //GET: AccountManagerController/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            var account = AccountManagerRes.Detail(id);
            return View(account);
        }

        [HttpPost]
        [Authorize]
        // POST: AccountManagerController/Edit
        public ActionResult Edit(int id, AccountManager account)
        {
            AccountManagerRes.Edit(account);
            return RedirectToAction(nameof(Index));
        }

        // GET: AccountManagerController/Delete
        [Authorize]
        public IActionResult Delete(int id)
        {
            AccountManagerRes.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/admin");
        }
    }
}