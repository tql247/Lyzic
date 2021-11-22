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
    public class ArtistController : Controller
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IWebHostEnvironment _environment;
        public ArtistController(ILogger<ArtistController> logger,  IWebHostEnvironment env) 
        {  
            _logger = logger;
            _environment = env;
        }
        

        public IActionResult Index()
        {
            var listArtist = ArtistRes.GetAll();
            return View(listArtist);
        }
        
        // GET: ArtistManagerController/Details
        public ActionResult Details(int id)
        {
            var music = ArtistRes.Detail(id);
            return View(music);
        }
    }
}