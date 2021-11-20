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
    public class NotificationManagerController : Controller
    {
        private readonly ILogger<NotificationManagerController> _logger;
        private readonly IWebHostEnvironment _environment;
        public NotificationManagerController(ILogger<NotificationManagerController> logger, IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        public IActionResult Index()
        {
            var listNotification = NotificationManagerRes.GetAll();
            return View(listNotification);
        }
        
        // GET: NotificationManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // GET: NotificationManagerController/Create
        public ActionResult Create(NotificationManager noti)
        {
            if (noti.MediaImageCover != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", noti.MediaImageCover.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                noti.MediaImageCover.CopyTo(fileStream);

                // Set file relative path
                noti.NotificationImage = Path.Combine("~/uploads/", noti.MediaImageCover.FileName);
            }    

            NotificationManagerRes.Insert(noti);

            return RedirectToAction(nameof(Index));
        }
        

       // GET: NotificationManagerController/Details
        public ActionResult Details(int id)
        {
            Console.WriteLine(_environment.WebRootPath);
            Console.WriteLine();
            
            var noti = NotificationManagerRes.Detail(id);
            return View(noti);
        }

        // GET: NotificationManagerController/Edit
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            var noti = NotificationManagerRes.Detail(id);
            return View(noti);
        }


        [HttpPost]
        // POST: NotificationManagerController/Edit
        public ActionResult Edit(int id, NotificationManager noti)
        {
            if (noti.MediaImageCover != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", noti.MediaImageCover.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                noti.MediaImageCover.CopyTo(fileStream);

                // Set file relative path
                noti.NotificationImage = Path.Combine("~/uploads/", noti.MediaImageCover.FileName);
            }
        

            NotificationManagerRes.Edit(noti);

            return RedirectToAction(nameof(Index));
        }

        // GET: NotificationManagerController/Delete
        public IActionResult Delete(int id)
        {
            NotificationManagerRes.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}