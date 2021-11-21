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
        
        public string Index() {
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


        // public IActionResult Index()
        // {
        //     var listaccount = AccountRes.GetAll();
        //     return View(listaccount);
        // }
        
        // // GET: AccountController/Create
        // public ActionResult Create()
        // {
        //     return View();
        // }


        // [HttpPost]
        // // GET: AccountController/Create
        // public ActionResult Create(Account account)
        // {
        //     AccountRes.Insert(account);

        //     return RedirectToAction(nameof(Index));
        // }
        

        // // // GET: AccountController/Details
        // public ActionResult Details(int id)
        // {
        //     var account = AccountRes.Detail(id);
        //     return View(account);
        // }

        // //GET: AccountController/Edit
        // public ActionResult Edit(int id)
        // {
        //     Console.WriteLine(id);
        //     var account = AccountRes.Detail(id);
        //     return View(account);
        // }

        // [HttpPost]
        // // POST: AccountController/Edit
        // public ActionResult Edit(int id, Account account)
        // {
        //     AccountRes.Edit(account);
        //     return RedirectToAction(nameof(Index));
        // }

        // // GET: AccountController/Delete
        // public IActionResult Delete(int id)
        // {
        //     AccountRes.Delete(id);
        //     return RedirectToAction(nameof(Index));
        // }

        
        public IActionResult SignIn()
        {
            return View();
        }

        // [HttpPost]
        // public async Task <ActionResult> Login(Account acc)
        // {
            
        // }
        
        // public IActionResult Logout()
        // {
        //     HttpContext.SignOutAsync();
        //     return Redirect("/Account/Login");
        // }
         public IActionResult SignUp()
        {
            return View();
        }

    }
}