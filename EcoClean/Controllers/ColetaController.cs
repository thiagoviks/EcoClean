using Microsoft.AspNetCore.Mvc;

namespace EcoClean.Controllers
{
    public class ColetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
