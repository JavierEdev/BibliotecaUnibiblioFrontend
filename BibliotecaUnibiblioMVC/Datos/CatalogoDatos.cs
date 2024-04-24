using BibliotecaUnibiblioMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

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
                            idLibro = Convert.ToInt32(dr["ID_Departamento"]),
                            Nombre = dr["Nombre"].ToString(),
                            Autor = dr["Autor"].ToString(),
                            anioPublicacion = dr["Año Publicacion"].ToString(),
                            grupoLibro = dr["Grupo Libro"].ToString(),
                            enStock = dr["En Stock"].ToString(),
                            estado = dr["Estado"].ToString(),
                            tipoIdentificador = dr["Tipo de identificador"].ToString(),
                            idArea = dr["ID Area"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }


    }
}
