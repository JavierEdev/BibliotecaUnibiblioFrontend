using BibliotecaUnibiblioMVC.Models;
using BibliotecaUnibiblioMVC.Datos;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class AdministradorLectorController : Controller
    {

        CatalogoDatos _CatalogoDatos = new CatalogoDatos();
        private readonly CatalogoDatos _catalogoDatos;

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

        public IActionResult InventarioVerLibrosAdministrador()
        {
            return View();
        }

        public IActionResult ReporteriaReporteGeneralAdministrador()
        {
            return View();
        }

        public IActionResult UsuariosVerColaboradoresAdministrador()
        {
            return View();
        }

        public IActionResult InventarioVerGrupoLibrosAdministrador()
        {
            return View();
        }

        public IActionResult InventarioVerAreaTematicaAdministrador()
        {
            return View();
        }

        public IActionResult VerUsuariosLectoresAdministrador()
        {
            var olista = _CatalogoDatos.ListarUsuarios();

            return View(olista);
        }

        public IActionResult HomeAdministradorValidacion(LoginModel oLogin) 
        {
            Seguridad validacionPassword = new Seguridad();
            var respuesta = validacionPassword.validarUsuario(oLogin);

            if (respuesta == true)
            {
                return RedirectToAction("HomeAdministrador");
            }
            else 
            {
                TempData["Alerta"] = "Usuario o password incorrectos";
                return RedirectToAction("IngresoAdministrador");
            }
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
