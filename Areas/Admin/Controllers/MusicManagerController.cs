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
    public class MusicManagerController : Controller
    {
        private readonly ILogger<MusicManagerController> _logger;
        private readonly IWebHostEnvironment _environment;
        public MusicManagerController(ILogger<MusicManagerController> logger, IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        [Authorize]
        public IActionResult Index()
        {
            var listMusic = MusicManagerRes.GetAll();
            return View(listMusic);
        }
        
        // GET: MusicManagerController/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        // GET: MusicManagerController/Create
        public ActionResult Create(MusicManager music)
        {
            if (music.MediaImageCover != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", music.MediaImageCover.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                music.MediaImageCover.CopyTo(fileStream);

                // Set file relative path
                music.MediaImageCoverURI = Path.Combine("~/uploads/", music.MediaImageCover.FileName);
            }
            
            if (music.MediaContent != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", music.MediaContent.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                music.MediaContent.CopyTo(fileStream);

                // Set file relative path
                music.MediaContentURI = Path.Combine("~/uploads/", music.MediaContent.FileName);
            }

            MusicManagerRes.Insert(music);

            return RedirectToAction(nameof(Index));
        }
        

        // GET: MusicManagerController/Details
        public ActionResult Details(int id)
        {
            Console.WriteLine(_environment.WebRootPath);
            Console.WriteLine();
            
            var music = MusicManagerRes.Detail(id);
            return View(music);
        }

        // GET: MusicManagerController/Edit
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            var music = MusicManagerRes.Detail(id);
            return View(music);
        }


        [HttpPost]
        // POST: MusicManagerController/Edit
        public ActionResult Edit(int id, MusicManager music)
        {
            if (music.MediaImageCover != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", music.MediaImageCover.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                music.MediaImageCover.CopyTo(fileStream);

                // Set file relative path
                music.MediaImageCoverURI = Path.Combine("~/uploads/", music.MediaImageCover.FileName);
            }
            
            if (music.MediaContent != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", music.MediaContent.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                music.MediaContent.CopyTo(fileStream);

                // Set file relative path
                music.MediaContentURI = Path.Combine("~/uploads/", music.MediaContent.FileName);
            }

            MusicManagerRes.Edit(music);

            return RedirectToAction(nameof(Index));
        }

        // GET: MusicManagerController/Delete
        public IActionResult Delete(int id)
        {
            Console.WriteLine("delete");
            Console.WriteLine("id: " + id);
            MusicManagerRes.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}