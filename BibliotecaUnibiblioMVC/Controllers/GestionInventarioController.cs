using BibliotecaUnibiblioMVC.Datos;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class GestionInventarioController : Controller
    {
        GestionInventarioDatos _GestionInventarioDatos = new GestionInventarioDatos();
        public IActionResult InvetarioVerLibrosAdministrador()
        {
            var olista = _GestionInventarioDatos.ListarLibros();
            return View();
        }
    }
}
