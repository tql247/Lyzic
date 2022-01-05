using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using CAIT.SQLHelper;
using System.Data;
using Lyzic.Const;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace Lyzic.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IWebHostEnvironment _environment;
        public ArtistController(ILogger<ArtistController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }

        // Trả về trang danh sách nghệ sĩ
        public IActionResult Index()
        {
            var listArtist = ArtistRes.GetAll();
            return View(listArtist);
        }

        // GET: ArtistManagerController/Details
        // Xem chi tiết nghệ sĩ
        public ActionResult Details(int id)
        {
            var artist = ArtistRes.Detail(id);
            
            dynamic multipleModel = new ExpandoObject();
            multipleModel.Artist = artist;
            multipleModel.Musics = MusicRes.GetMusicByArtist(artist.Name);
 
            return View(multipleModel);
        }
    }
}