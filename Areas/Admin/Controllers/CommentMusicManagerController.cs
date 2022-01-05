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
    public class CommentMusicManagerController : Controller
    {
        private readonly ILogger<CommentMusicManagerController> _logger;
        private readonly IWebHostEnvironment _environment;
        public CommentMusicManagerController(ILogger<CommentMusicManagerController> logger, IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        // [Authorize]
        public IActionResult Index()
        {
            var listComment = CommentMusicManagerRes.GetAll();
            return View(listComment);
        }

        // GET: CommentMusicManagerController/Delete
        public IActionResult Delete(int id)
        {
            CommentMusicManagerRes.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}