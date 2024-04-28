using BibliotecaUnibiblioMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaUnibiblioMVC.Datos
{
    public class UsuarioCreacion
    {

        internal Seguridad encriptar = new Seguridad();

        public bool Guardar(usuarioModel oUsuario)
        {
            bool rpt;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_registroUsuario", conexion);
                    cmd.Parameters.AddWithValue("primerNombre", oUsuario.primerNombre);
                    cmd.Parameters.AddWithValue("segundoNombre", oUsuario.segundoNombre ?? "");
                    cmd.Parameters.AddWithValue("primerApellido", oUsuario.primerApellido ?? "");
                    cmd.Parameters.AddWithValue("segundoApellido", oUsuario.segundoApellido ?? "");
                    cmd.Parameters.AddWithValue("dpi", oUsuario.dpi ?? "");
                    cmd.Parameters.AddWithValue("telefono", oUsuario.telefono ?? "");
                    cmd.Parameters.AddWithValue("correo", oUsuario.correo ?? "");
                    cmd.Parameters.AddWithValue("direccion", oUsuario.direccion ?? "");
                    cmd.Parameters.AddWithValue("rol", oUsuario.rol);
                    cmd.Parameters.AddWithValue("contrasena", encriptar.EncriptarBase64(oUsuario.confirmarContrasena ?? ""));

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    rpt = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpt = false;
            }

            return rpt;
        }
    }
}
