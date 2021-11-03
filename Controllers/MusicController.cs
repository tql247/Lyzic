using System.IO;
using System.Linq;
using Lyzic.Services;
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
        private readonly ProductService _productService;
        private readonly IWebHostEnvironment _environment;
        public MusicController(ILogger<MusicController> logger, ProductService productService, IWebHostEnvironment env) 
        {  
            _logger = logger;
            _productService = productService;
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
        

        // GET: LaptopController/Details
        public ActionResult Details(int id)
        {
            Console.WriteLine(_environment.WebRootPath);
            Console.WriteLine();
            
            var music = MusicRes.Detail(id);
            return View(music);
        }

        // GET: LaptopController/Edit
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            var music = MusicRes.Detail(id);
            return View(music);
        }

        // GET: LaptopController/Delete
        public IActionResult Delete(int id)
        {
            Console.WriteLine(id);
            MusicRes.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}