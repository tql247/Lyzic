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
    public class ArtistManagerController : Controller
    {
        private readonly ILogger<ArtistManagerController> _logger;
        private readonly IWebHostEnvironment _environment;
        public ArtistManagerController(ILogger<ArtistManagerController> logger, IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        [Authorize]
        public IActionResult Index()
        {
            var listArtist = ArtistManagerRes.GetAll();
            return View(listArtist);
        }
        
        // GET: ArtistManagerController/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        // GET: ArtistManagerController/Create
        public ActionResult Create(ArtistManager artist)
        {
            if (artist.MediaImageCover != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", artist.MediaImageCover.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                artist.MediaImageCover.CopyTo(fileStream);

                // Set file relative path
                artist.AvatarImageURI = Path.Combine("~/uploads/", artist.MediaImageCover.FileName);
            }    

            Console.WriteLine("Huhu");
            Console.WriteLine(artist.Name);

            
            ArtistManagerRes.Insert(artist);

            return RedirectToAction(nameof(Index));
        }
        

        // GET: ArtistManagerController/Details
        public ActionResult Details(int id)
        {
            Console.WriteLine(_environment.WebRootPath);
            Console.WriteLine();
            
            var music = ArtistManagerRes.Detail(id);
            return View(music);
        }

        // GET: ArtistManagerController/Edit
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            var music = ArtistManagerRes.Detail(id);
            return View(music);
        }


        [HttpPost]
        // POST: ArtistManagerController/Edit
        public ActionResult Edit(int id, ArtistManager artist)
        {
            if (artist.MediaImageCover != null) {
                // Save file                 
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", artist.MediaImageCover.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                artist.MediaImageCover.CopyTo(fileStream);

                // Set file relative path
                artist.AvatarImageURI = Path.Combine("~/uploads/", artist.MediaImageCover.FileName);
            }

            ArtistManagerRes.Edit(artist);

            return RedirectToAction(nameof(Index));
        }

        // GET: ArtistManagerController/Delete
        public IActionResult Delete(int id)
        {
            ArtistManagerRes.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}