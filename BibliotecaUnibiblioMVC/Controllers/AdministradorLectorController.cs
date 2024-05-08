using BibliotecaUnibiblioMVC.Models;
using BibliotecaUnibiblioMVC.Datos;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class AdministradorLectorController : Controller
    {
        #region Vistas
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

        public IActionResult InventarioVerGrupoLibrosAdministrador()
        {
            return View();
        }

        public IActionResult InventarioVerAreaTematicaAdministrador()
        {
            return View();
        }

        public IActionResult ModificarUsuariosLectoresAdministrador(int Id)
        {
            CRUDUsuarios crud = new CRUDUsuarios();

            var retornar = crud.obtenerUsuario(Id);

            return View(retornar);
        }

        public IActionResult ModificarColaboradoresAdministrador(int Id)
        {
            CRUDUsuarios crud = new CRUDUsuarios();

            var retornar = crud.obtenerUsuario(Id);

            return View(retornar);
        }

        public IActionResult VerUsuariosLectoresAdministrador()
        {
            var olista = _CatalogoDatos.ListarUsuarios();

            return View(olista);
        }

        public IActionResult UsuariosVerColaboradoresAdministrador()
        {
            var olista = _CatalogoDatos.ListarColaboradores();

            return View(olista);
        }

        public IActionResult PrestamosAdministrador()
        {
            return View();
        }

        #endregion

        #region Metodos

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

        [HttpPost]
        public IActionResult CRUDBasicoUsuarios(int Id, string primerNombre, string primerApellido, string Telefono, string Direccion, DateTime fechaSuspension,string motivoSuspension, int accion)
        {
            CRUDUsuarios crud = new CRUDUsuarios();

            switch (accion)
            {
                case 1:
                    crud.modificarUsuario(Id,primerNombre,primerApellido,Telefono,Direccion);
                    break;
                case 2:
                    crud.inactivarUsuario(Id, primerNombre, primerApellido, Telefono, Direccion);
                    break;
                case 3:
                    crud.suspenderUsuario(Id, fechaSuspension, motivoSuspension);
                    break;
            }

            return RedirectToAction("VerUsuariosLectoresAdministrador");
        }

        [HttpPost]
        public IActionResult CRUDBasicoColaboradores(int Id, string primerNombre, string primerApellido, string Telefono, string Direccion, int accion)
        {
            CRUDUsuarios crud = new CRUDUsuarios();

            switch (accion)
            {
                case 1:
                    crud.modificarUsuario(Id, primerNombre, primerApellido, Telefono, Direccion);
                    break;
                case 2:
                    crud.inactivarUsuario(Id, primerNombre, primerApellido, Telefono, Direccion);
                    break;
            }

            return RedirectToAction("UsuariosVerColaboradoresAdministrador");
        }
        #endregion
    }
}
