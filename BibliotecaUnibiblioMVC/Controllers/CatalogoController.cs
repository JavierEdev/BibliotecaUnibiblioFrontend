using BibliotecaUnibiblioMVC.Datos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class CatalogoController : Controller
    {
        CatalogoDatos _CatalogoDatos = new CatalogoDatos();
        private readonly CatalogoDatos _catalogoDatos;
        public IActionResult Catalogo()
        {
           
            var olista = _CatalogoDatos.ListarCatalogo();

            return View(olista);
        }

        public IActionResult BuscarLibros(string nombreLibro)
        {
            var librosEncontrados = _catalogoDatos.BuscarLibrosPorNombre(nombreLibro);
            return View(librosEncontrados);
        }

        public IActionResult CatalogoLector()
        {
            var olista = _CatalogoDatos.ListarCatalogo();
            return View(olista);
        }

        public IActionResult CatalogoLectorBuscarLibros(string nombreLibro)
        {
            var librosEncontrados = _catalogoDatos.BuscarLibrosPorNombre(nombreLibro);
            return View(librosEncontrados);
        }

    }
}
