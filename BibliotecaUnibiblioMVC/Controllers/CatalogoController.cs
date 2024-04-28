using BibliotecaUnibiblioMVC.Datos;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult CatalogoLector()
        {
            CatalogoDatos _CatalogoDatos = new CatalogoDatos();
            var olista = _CatalogoDatos.ListarCatalogo();

            return View(olista);
        }
    }
}
