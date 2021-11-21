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
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly IWebHostEnvironment _environment;
        public NotificationController(ILogger<NotificationController> logger,  IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        public IActionResult Index()
        {
            var listNotification = NotificationRes.GetAll();
            return View(listNotification);
        }
        
        //GET: NotificationManagerController/Details
        public ActionResult Details(int id)
        {
           var notification = NotificationRes.Detail(id);
            return View(notification);
        }
    }
}