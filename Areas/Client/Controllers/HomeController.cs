using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Lyzic.Repositories;
using System.Dynamic;


namespace Lyzic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Trả về trang chủ
        public IActionResult Index()
        {
            var listMusic = MusicRes.GetAll();
            var listArtist = ArtistRes.GetAll();
            var listNotification = NotificationRes.GetAll();
            
            dynamic multipleModel = new ExpandoObject();
            multipleModel.Musics = listMusic.GetRange(0, Math.Min (listMusic.Count, 10));
            multipleModel.Notifications = listNotification.GetRange(0, Math.Min (listNotification.Count, 3));
            multipleModel.Artists = listArtist.GetRange(0, Math.Min (listArtist.Count, 6));

            return View(multipleModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
