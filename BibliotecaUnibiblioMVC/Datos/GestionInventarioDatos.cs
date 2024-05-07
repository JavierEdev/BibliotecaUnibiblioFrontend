﻿using BibliotecaUnibiblioMVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace BibliotecaUnibiblioMVC.Datos
{
    public class GestionInventarioDatos
    {
    //Procedimientos para tabla Libros
        //leer Tabla Libros(Select)
        public List<CatalogoModel> ListarLibros()
        {

            var oLista = new List<CatalogoModel>();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_SelectLibros", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new CatalogoModel()
                        {
                            idLibro = Convert.ToInt32(dr["idLibro"]),
                            Nombre = dr["Nombre"].ToString(),
                            Autor = dr["Autor"].ToString(),
                            anioPublicacion = (DateTime?)dr["anioPublicacion"],
                            grupoLibro = Convert.ToInt32(dr["grupoLibro"]),
                            enStock = Convert.ToInt32(dr["enStock"]),
                            estado = Convert.ToInt32(dr["estado"]),
                            tipoIdentificador = Convert.ToInt32(dr["tipoIdentificador"]),
                            idArea = Convert.ToInt32(dr["idArea"])
                        });
                    }
                }
            }
            return oLista;
        }
        //Guardar Tabla Libros(Insert)
        public bool GuardarLibro(CatalogoModel oLibros)
        {
            
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarLibro", Conexion);
                    cmd.Parameters.AddWithValue("Nombre", oLibros.Nombre);
                    cmd.Parameters.AddWithValue("Autor", oLibros.Autor);
                    cmd.Parameters.AddWithValue("anioPublicacion", oLibros.anioPublicacion);
                    cmd.Parameters.AddWithValue("grupoLibro", oLibros.grupoLibro);
                    cmd.Parameters.AddWithValue("enStock", oLibros.enStock);
                    cmd.Parameters.AddWithValue("estado", oLibros.estado);
                    cmd.Parameters.AddWithValue("tipoIdentificador", oLibros.tipoIdentificador);
                    cmd.Parameters.AddWithValue("idArea", oLibros.idArea);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        //Obtencion de datos para diferentes metodos de la tabla Libros
        public CatalogoModel ObtenerLibro(int idLibro)
        {
            
            var oLibros = new CatalogoModel();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerLibro", Conexion);
                cmd.Parameters.AddWithValue("idLibro ", idLibro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLibros.idLibro = Convert.ToInt32(dr["idLibro"]);
                        oLibros.Nombre = dr["Nombre"].ToString();
                        oLibros.Autor = dr["Autor"].ToString();
                        oLibros.anioPublicacion = (DateTime?)dr["anioPublicacion"];
                        oLibros.grupoLibro = Convert.ToInt32(dr["grupoLibro"]);
                        oLibros.enStock = Convert.ToInt32(dr["enStock"]);
                        oLibros.estado = Convert.ToInt32(dr["estado"]);
                        oLibros.tipoIdentificador = Convert.ToInt32(dr["tipoIdentificador"]);
                        oLibros.idArea = Convert.ToInt32(dr["idArea"]);


                    }
                }
            }
            return oLibros;
        }
        //Edicion de datos Tabla Libros(update)
        public bool EditarLibro(CatalogoModel oLibros)
        {
            
            bool rpta;

            try
            {
                var oLista = new List<CatalogoModel>();

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ModificarLibro", Conexion);
                    cmd.Parameters.AddWithValue("Nombre", oLibros.Nombre);
                    cmd.Parameters.AddWithValue("Autor", oLibros.Autor);
                    cmd.Parameters.AddWithValue("anioPublicacion", oLibros.anioPublicacion);
                    cmd.Parameters.AddWithValue("grupoLibro", oLibros.grupoLibro);
                    cmd.Parameters.AddWithValue("enStock", oLibros.enStock);
                    cmd.Parameters.AddWithValue("estado", oLibros.estado);
                    cmd.Parameters.AddWithValue("tipoIdentificador", oLibros.tipoIdentificador);
                    cmd.Parameters.AddWithValue("idArea", oLibros.idArea);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        //Eliminar datos de tabla Libros(delete)
        public bool EliminarLibro(int idLibro)
        {
            
            bool rpta;

            try
            {
                var oLista = new List<CatalogoModel>();

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarLibro", Conexion);
                    cmd.Parameters.AddWithValue("idLibro", idLibro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        //Procedimientos para tabla Grupo Libro
        //leer Tabla Grupo Libro(Select)
        public List<GrupoLibrosModel> ListarGrupos()
        {

            var oLista = new List<GrupoLibrosModel>();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_SeleccionarGruposLibro", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new GrupoLibrosModel()
                        {
                            idGrupoLibro = Convert.ToInt32(dr["idGrupoLibro"]),
                            descripcion = dr["descripcion"].ToString(),
                           
                        });
                    }
                }
            }
            return oLista;
        }
        //Guardar Tabla Grupo Libro(Insert)
        public bool GuardarGrupo(GrupoLibrosModel oGrupo)
        {

            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarGrupoLibro", Conexion);
                    cmd.Parameters.AddWithValue("idGrupoLibro", oGrupo.idGrupoLibro);
                    cmd.Parameters.AddWithValue("descripcion", oGrupo.descripcion);
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        //Obtencion de datos para diferentes metodos de la tabla Grupo Libro
        public GrupoLibrosModel ObtenerGrupo(int idGrupoLibro)
        {

            var oGrupo = new GrupoLibrosModel();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerGrupoLibro", Conexion);
                cmd.Parameters.AddWithValue("idGrupoLibro", idGrupoLibro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oGrupo.idGrupoLibro = Convert.ToInt32(dr["idGrupoLibro"]);
                        oGrupo.descripcion = dr["descripcion"].ToString();
                       
                    }
                }
            }
            return oGrupo;
        }
        //Edicion de datos Tabla Grupo Libro(update)
        public bool EditarGrupo(GrupoLibrosModel oGrupo)
        {

            bool rpta;

            try
            {
                var oLista = new List<GrupoLibrosModel>();

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarGrupoLibro", Conexion);
                    cmd.Parameters.AddWithValue("idGrupoLibro", oGrupo.idGrupoLibro);
                    cmd.Parameters.AddWithValue("descripcion", oGrupo.descripcion);
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        //Eliminar datos de tabla Grupo Libro (delete)
        public bool EliminarGrupo(int idGrupoLibro)
        {

            bool rpta;

            try
            {
                var oLista = new List<GrupoLibrosModel>();

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarGrupoLibro", Conexion);
                    cmd.Parameters.AddWithValue("idGrupoLibro", idGrupoLibro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        //Procedimientos para tabla Area Tematica
        //leer Tabla Area Tematica(Select)
        public List<AreaTematicaModel> ListarAreaTematica()
        {

            var oLista = new List<AreaTematicaModel>();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_SeleccionarAreasTematica", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new AreaTematicaModel()
                        {
                            idArea = Convert.ToInt32(dr["idArea"]),
                            descripcion = dr["descripcion"].ToString(),

                        });
                    }
                }
            }
            return oLista;
        }
        //Guardar Tabla Area Tematica(Insert)
        public bool GuardarAreaTematica(AreaTematicaModel oArea)
        {

            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarAreaTematica", Conexion);
                    cmd.Parameters.AddWithValue("idArea", oArea.idArea);
                    cmd.Parameters.AddWithValue("descripcion", oArea.descripcion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        //Obtencion de datos para diferentes metodos de la tabla Area Tematica
        public AreaTematicaModel ObtenerArea(int idArea)
        {

            var oArea = new AreaTematicaModel();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerAreaTematica", Conexion);
                cmd.Parameters.AddWithValue("idarea", idArea);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oArea.idArea = Convert.ToInt32(dr["idArea"]);
                        oArea.descripcion = dr["descripcion"].ToString();

                    }
                }
            }
            return oArea;
        }
        //Edicion de datos Tabla Area Tematica(update)
        public bool EditarArea(AreaTematicaModel oArea)
        {

            bool rpta;

            try
            {
                var oLista = new List<GrupoLibrosModel>();

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarAreaTematica", Conexion);
                    cmd.Parameters.AddWithValue("idArea", oArea.idArea);
                    cmd.Parameters.AddWithValue("descripcion", oArea.descripcion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        //Eliminar datos de tabla Area Tematica(delete)
        public bool EliminarArea(int idArea)
        {

            bool rpta;

            try
            {
                var oLista = new List<AreaTematicaModel>();

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarAreaTematica", Conexion);
                    cmd.Parameters.AddWithValue("idArea", idArea);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}