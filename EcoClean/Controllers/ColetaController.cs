using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcoClean.Controllers
{
    public class ColetaController : Controller
    {
        private readonly ILogger<ColetaController> _logger;
        private readonly DatabaseContext _context;

        public ColetaController(ILogger<ColetaController> logger, DatabaseContext context) 
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
