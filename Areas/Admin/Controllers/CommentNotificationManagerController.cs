using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Lyzic.Controllers
{
    public class CommentNotificationManagerController : Controller
    {
        private readonly ILogger<CommentNotificationManagerController> _logger;
        private readonly IWebHostEnvironment _environment;
        public CommentNotificationManagerController(ILogger<CommentNotificationManagerController> logger, IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        // [Authorize]
        public IActionResult Index()
        {
            var listComment = CommentNotificationManagerRes.GetAll();
            return View(listComment);
        }

        // GET: CommentNotificationManagerController/Delete
        public IActionResult Delete(int id)
        {
            CommentNotificationManagerRes.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}