using BibliotecaUnibiblioMVC.Models;
using System.Data.SqlClient;
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


    }
}
