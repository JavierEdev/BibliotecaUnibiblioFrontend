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
            return View(olista);
        }

        public IActionResult InvetarioVerGrupoLibrosAdministrador()
        {
            var olista = _GestionInventarioDatos.ListarGrupos();
            return View(olista);
        }
        public IActionResult InvetarioVerAreaTematicaAdministrador()
        {
            var olista = _GestionInventarioDatos.ListarAreaTematica();
            return View(olista);
        }
    }
}
