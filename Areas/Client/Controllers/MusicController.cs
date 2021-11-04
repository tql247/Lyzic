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
    public class MusicController : Controller
    {
        private readonly ILogger<MusicController> _logger;
        private readonly IWebHostEnvironment _environment;
        public MusicController(ILogger<MusicController> logger,  IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        public IActionResult Index()
        {
            var listMusic = MusicRes.GetAll();
            return View(listMusic);
        }
        
        // GET: MusicController/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        // GET: MusicController/Create
        public ActionResult Create(Music music)
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

            MusicRes.Insert(music);

            return RedirectToAction(nameof(Index));
        }
        

        // GET: MusicController/Details
        public ActionResult Details(int id)
        {
            Console.WriteLine(_environment.WebRootPath);
            Console.WriteLine();
            
            var music = MusicRes.Detail(id);
            return View(music);
        }

        // GET: MusicController/Edit
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            var music = MusicRes.Detail(id);
            return View(music);
        }


        [HttpPost]
        // POST: MusicController/Edit
        public ActionResult Edit(int id, Music music)
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

            MusicRes.Edit(music);

            return RedirectToAction(nameof(Index));
        }

        // GET: MusicController/Delete
        public IActionResult Delete(int id)
        {
            Console.WriteLine(id);
            MusicRes.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}