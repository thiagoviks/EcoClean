using Microsoft.AspNetCore.Mvc;

namespace EcoClean.Controllers
{
    public class NotificacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
