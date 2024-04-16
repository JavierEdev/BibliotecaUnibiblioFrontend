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

        [HttpPost]
        public IActionResult GuardarUsuario(usuarioModel oUsuario)
        {
            UsuarioCreacion _usuariosDatos = new UsuarioCreacion();
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreacionNuevoUsuario");
            }

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

        public IActionResult CreacionNuevoUsuario() {
            return View();
        }


    }
}
