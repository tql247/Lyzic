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
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly IWebHostEnvironment _environment;
        public NotificationController(ILogger<NotificationController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }

        // Trả về danh sách thông báo
        public IActionResult Index()
        {
            var listNotification = NotificationRes.GetAll();
            return View(listNotification);
        }

        //GET: NotificationManagerController/Details
        public ActionResult Details(int id)
        {
            // Get music and list comment
            var (notification, commentList) = NotificationRes.Detail(id);

            dynamic multipleModel = new ExpandoObject();
            multipleModel.Notification = notification;
            // multipleModel.Relates = MusicRes.GetMusicByArtist(music.Singers);
            multipleModel.CommentList = commentList.ToList();

            // Return multiple model(Music, List<Comment>) to view
            return View(multipleModel);
        }
    }
}