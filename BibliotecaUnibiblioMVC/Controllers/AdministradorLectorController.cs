using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class AdministradorLectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
