using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;

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
        

        public IActionResult Index()
        {
            var listaccount = AccountManagerRes.GetAll();
            return View(listaccount);
        }
        
        // GET: AccountManagerController/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        // GET: AccountManagerController/Create
        public ActionResult Create(AccountManager account)
        {
            AccountManagerRes.Insert(account);

            return RedirectToAction(nameof(Index));
        }
        

        // // GET: AccountManagerController/Details
        public ActionResult Details(int id)
        {
            var account = AccountManagerRes.Detail(id);
            return View(account);
        }

        //GET: AccountManagerController/Edit
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            var account = AccountManagerRes.Detail(id);
            return View(account);
        }

        [HttpPost]
        // POST: AccountManagerController/Edit
        public ActionResult Edit(int id, AccountManager account)
        {
            AccountManagerRes.Edit(account);
            return RedirectToAction(nameof(Index));
        }

        // GET: AccountManagerController/Delete
        public IActionResult Delete(int id)
        {
            AccountManagerRes.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}