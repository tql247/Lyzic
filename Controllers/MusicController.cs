using System.IO;
using System.Linq;
using Lyzic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            return View();
        }
    }
}