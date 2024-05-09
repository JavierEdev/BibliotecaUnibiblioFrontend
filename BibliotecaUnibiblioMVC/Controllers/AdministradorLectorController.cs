﻿using BibliotecaUnibiblioMVC.Models;
using BibliotecaUnibiblioMVC.Datos;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUnibiblioMVC.Controllers
{
    public class AdministradorLectorController : Controller
    {
        #region Vistas
        GestionInventarioDatos _GestionInventarioDatos = new GestionInventarioDatos();
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

        public IActionResult ModificarAreaTematicaAdministrador(int idGrupoLibro)
        {
            var oEmpleados = _GestionInventarioDatos.ObtenerArea(idGrupoLibro);
            return View(oEmpleados);
        }
        public IActionResult InventarioVerLibrosAdministrador()
        {
            var olista = _GestionInventarioDatos.ListarLibros();
            return View(olista);
        }

        public IActionResult NuevoEjemplaresAgregarAdministrador()
        {
            return View();
        }
        public IActionResult ModificarEjemplaresAdministrador(int idLibro)
        {
            //Metodo devuelve la vista
            var oEmpleados = _GestionInventarioDatos.ObtenerLibro(idLibro);
            return View(oEmpleados);
        }
        public IActionResult NuevoGrupoAdministrador()
        {
            return View();
        }
        public IActionResult InventarioVerAreaTematicaAdministrador()
        {
            var olista = _GestionInventarioDatos.ListarAreaTematica();
            return View(olista);
        }

        public IActionResult NuevoAreaTematicaAdministrador()
        {
            return View();
        }

        public IActionResult InventarioVerGrupoLibrosAdministrador()
        {
            var olista = _GestionInventarioDatos.ListarGrupos();
            return View(olista);
        }
        public IActionResult ModificarGrupoAdministrador(int idGrupoLibro)
        {
            var oEmpleados = _GestionInventarioDatos.ObtenerGrupo(idGrupoLibro);
            return View(oEmpleados);
        }

        public IActionResult ReporteriaReporteGeneralAdministrador()
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

        [HttpPost]
        public IActionResult ModificarEjemplaresAdministrador(CatalogoModel oLibros)
        {
            //Metodo devuelve la vista
            if (!ModelState.IsValid)
                return View();

            var respuesta = _GestionInventarioDatos.EditarLibro(oLibros);

            if (respuesta)
                return RedirectToAction("InventarioVerLibrosAdministrador");
            else
                return View();
        }
        [HttpPost]
        public IActionResult EliminarLibro(CatalogoModel oLibros)
        {
            //Metodo devuelve la vista

            var respuesta = _GestionInventarioDatos.EliminarLibro(oLibros.idLibro);

            if (respuesta)
                return RedirectToAction("InventarioVerLibrosAdministrador");
            else
                return View();
        }

        [HttpPost]
        public IActionResult ModificarAreaTematicaAdministrador(AreaTematicaModel oArea)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _GestionInventarioDatos.EditarArea(oArea);

            if (respuesta)
                return RedirectToAction("InventarioVerAreaTematicaAdministrador");
            else
                return View();
        }
        [HttpPost]
        public IActionResult EliminarArea(AreaTematicaModel oArea)
        {
            var respuesta = _GestionInventarioDatos.EliminarArea(oArea.idArea);

            if (respuesta)
                return RedirectToAction("InventarioVerAreaTematicaAdministrador");
            else
                return View();
        }

        [HttpPost]
        public IActionResult CRUDGrupos(GrupoLibrosModel oGrupo, int accion)
        {
            bool respuesta = false;
            bool eliminar = false;
            switch (accion) 
            {
                case 1:
                    respuesta = _GestionInventarioDatos.EditarGrupo(oGrupo);
                break;
                case 2:
                    eliminar = _GestionInventarioDatos.EliminarGrupo(oGrupo.idGrupoLibro);
                break;
            }

            if (respuesta == true || eliminar == true)
            {
                return RedirectToAction("InventarioVerGrupoLibrosAdministrador");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult NuevoGrupoAdministrador(GrupoLibrosModel oGrupo)
        {
            //Metodo recibe el objeto para guardar 
            if (!ModelState.IsValid)
                return View();

            var respuesta = _GestionInventarioDatos.GuardarGrupo(oGrupo);

            if (respuesta)
                return RedirectToAction("InventarioVerGrupoLibrosAdministrador");
            else
                return View();
        }

        [HttpPost]
        public IActionResult GuardarNuevaAreaTematica(AreaTematicaModel oArea)
        {
            //Metodo recibe el objeto para guardar 
            if (!ModelState.IsValid)
                return View();

            var respuesta = _GestionInventarioDatos.GuardarAreaTematica(oArea);

            if (respuesta)
                return RedirectToAction("InventarioVerAreaTematicaAdministrador");
            else
                return RedirectToAction("NuevoAreaTematicaAdministrador");
        }
        [HttpPost]
        public IActionResult NuevoAreaTematicaAdministrador(AreaTematicaModel oArea)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _GestionInventarioDatos.EditarArea(oArea);

            if (respuesta)
                return RedirectToAction("InventarioVerAreaTematicaAdministrador");
            else
                return View();
        }

        [HttpPost]
        public IActionResult NuevoEjemplaresAgregarAdministrador(CatalogoModel oEmpleados)
        {
            //Metodo recibe el objeto para guardar 
            if (!ModelState.IsValid)
                return View();

            var respuesta = _GestionInventarioDatos.GuardarLibro(oEmpleados);

            if (respuesta)
                return RedirectToAction("InventarioVerLibrosAdministrador");
            else
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
        #endregion
    }
}
