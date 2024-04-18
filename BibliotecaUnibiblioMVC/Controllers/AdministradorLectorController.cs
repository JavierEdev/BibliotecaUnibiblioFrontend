using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class AdministradorLectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IngresoLector()
        {
            return View();
        }

        public IActionResult IngresoAdministrador()
        {
            return View();
        }

        public IActionResult CreacionNuevoUsuario()
        {
            return View();
        }

        public IActionResult PrestamosAdmin()
        {
            return View();
        }

    }
}
