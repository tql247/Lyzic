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
            Console.WriteLine(music);
            Console.WriteLine(music.MediaImageCover);
            if (music.MediaImageCover != null) {
                
                Console.WriteLine(music.MediaImageCover.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", music.MediaImageCover.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                music.MediaImageCover.CopyTo(fileStream);
                Console.WriteLine(Path.Combine("~/uploads/", music.MediaImageCover.FileName));
                Console.WriteLine(filePath);
            }

            return View();
        }
    }
}