using BibliotecaUnibiblioMVC.Models;
using BibliotecaUnibiblioMVC.Datos;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class AdministradorLectorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IngresoAdministrador()
        {
            return View();
        }

        public IActionResult IngresoLector() 
        {
            return View();
        }

        public IActionResult CreacionNuevoUsuario()
        {
            return View();
        }

        public IActionResult HomeAdministrador() 
        {
            return View();
        }

        public IActionResult PrestamosAdministrador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarUsuario(usuarioModel oUsuario)
        {
            UsuarioCreacion _usuariosDatos = new UsuarioCreacion();

            var repuesta = _usuariosDatos.Guardar(oUsuario);

            if (repuesta == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreacionNuevoUsuario");
            }
        }

    }
}
