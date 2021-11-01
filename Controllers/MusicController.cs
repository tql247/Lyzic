using System.IO;
using System.Linq;
using Lyzic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;

namespace Lyzic.Controllers
{
    public class MusicController : Controller
    {
        private readonly ILogger<MusicController> _logger;
        private readonly ProductService _productService;
        public MusicController(ILogger<MusicController> logger, ProductService productService) 
        {  
            _logger = logger;
            _productService = productService;
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
    }
}