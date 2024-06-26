using Microsoft.AspNetCore.Mvc;

namespace EcoClean.Controllers
{
    public class MoradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
