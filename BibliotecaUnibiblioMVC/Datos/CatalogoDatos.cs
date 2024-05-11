using BibliotecaUnibiblioMVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace BibliotecaUnibiblioMVC.Datos
{
    public class CatalogoDatos
    {

        public List<CatalogoModel> ListarCatalogo()
        {

            //leer Tabla Libros(Select)

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

        //Buscar Libro
        public List<CatalogoModel> BuscarLibrosPorNombre(string nombreLibro)
        {
            var oLista = new List<CatalogoModel>();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarLibroPorNombre", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombreLibro);

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

        public List<MostrarUsuarios> ListarUsuarios()
        {

            //leer Tabla Libros(Select)

            var oLista = new List<MostrarUsuarios>();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_verUsuarios", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new MostrarUsuarios()
                        {   
                            Id = Convert.ToInt32(dr["Id"]),
                            NombreCompleto = dr["Nombre"].ToString(),
                            DPI = dr["DPI"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Direccion = dr["direccion"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public List<ListadoPrestamos> ListarPrestamos()
        {

            //leer Tabla Libros(Select)

            var oLista = new List<ListadoPrestamos>();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_verPrestamosUsuarios", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ListadoPrestamos()
                        {
                            idLibro = Convert.ToInt32(dr["Id"]),
                            nombreLibro = dr["Nombre"].ToString(),
                            fechaCreacion = (DateTime)dr["fechaCreacion"],
                            fechaFinalizacion = (DateTime)dr["fechaFinalizacion"],
                            correo = dr["correo"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public List<MostrarUsuarios> ListarColaboradores()
        {
            var oLista = new List<MostrarUsuarios>();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_verUsuariosColaboradores", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new MostrarUsuarios()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            NombreCompleto = dr["Nombre"].ToString(),
                            DPI = dr["DPI"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Direccion = dr["direccion"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Prestamo obtenerLibro(int Id)
        {
            var oObtener = new Prestamo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerNombreLibro", conexion);
                cmd.Parameters.AddWithValue("id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oObtener.IdLibro = Convert.ToInt32(dr["Id"]);
                        oObtener.NombreLibro = dr["nombreLibro"].ToString();
                        oObtener.fechaRetorno = (DateTime)dr["fechaEntrega"];
                    }
                }
            }
            return oObtener;
        }

        public Prestamo obtenerLibroDevolucion(int Id, string usuario)
        {
            var oObtener = new Prestamo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerNombreLibroPrestamo", conexion);
                cmd.Parameters.AddWithValue("id", Id);
                cmd.Parameters.AddWithValue("usuario",usuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oObtener.IdLibro = Convert.ToInt32(dr["Id"]);
                        oObtener.NombreLibro = dr["nombreLibro"].ToString();
                        oObtener.correoUsuario = dr["correo"].ToString();
                    }
                }
            }
            return oObtener;
        }

        public bool CrearPrestamo(Prestamo oPrestamo)
        {

            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_insertarPrestamo", Conexion);
                    cmd.Parameters.AddWithValue("correoUsuario", oPrestamo.correoUsuario);
                    cmd.Parameters.AddWithValue("fechaDevolucion", oPrestamo.fechaRetorno);
                    cmd.Parameters.AddWithValue("tipoPrestamo", oPrestamo.idPrestamo);
                    cmd.Parameters.AddWithValue("idLibro", oPrestamo.IdLibro);
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

        public bool DevolverPrestamo(Prestamo oPrestamo)
        {

            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_DevolverLibro", Conexion);
                    cmd.Parameters.AddWithValue("correoUsuario", oPrestamo.correoUsuario);
                    cmd.Parameters.AddWithValue("idLibro", oPrestamo.IdLibro);
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
