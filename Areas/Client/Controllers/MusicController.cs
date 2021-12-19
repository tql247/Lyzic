using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Dynamic;

namespace Lyzic.Controllers
{
    public class MusicController : Controller
    {
        private readonly ILogger<MusicController> _logger;
        private readonly IWebHostEnvironment _environment;
        public MusicController(ILogger<MusicController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }


        public IActionResult Index()
        {
            var listMusic = MusicRes.GetAll();
            return View(listMusic);
        }

        // GET: MusicManagerController/Details
        public ActionResult Details(int id)
        {
            // Get music and list comment
            var (music, commentList) = MusicRes.Detail(id);

            dynamic multipleModel = new ExpandoObject();
            multipleModel.Music = music;
            multipleModel.CommentList = commentList.ToList();

            // Return multiple model(Music, List<Comment>) to view
            return View(multipleModel);
        }
    }
}