using BibliotecaUnibiblioMVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace BibliotecaUnibiblioMVC.Datos
{
    public class CRUDUsuarios
    {
        public MostrarUsuarios obtenerUsuario(int Id)
        {
            var oObtener = new MostrarUsuarios();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener_usuario", conexion);
                cmd.Parameters.AddWithValue("id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oObtener.Id = Convert.ToInt32(dr["id"]);
                        oObtener.primerNombre = dr["primerNombre"].ToString();
                        oObtener.primerApellido = dr["primerApellido"].ToString();
                        oObtener.Telefono = dr["telefono"].ToString();
                        oObtener.Direccion = dr["direccion"].ToString();
                        oObtener.fechaSuspension = (dr["fechaFinalizaSuspension"] as DateTime?) ?? DateTime.Today;
                    }
                }
            }
            return oObtener;
        }

        public bool modificarUsuario(int Id, string primerNombre, string primerApellido, string Telefono, string Direccion)
        {
            bool rpt;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_modificar_usuario", conexion);
                    cmd.Parameters.AddWithValue("id", Id);
                    cmd.Parameters.AddWithValue("primerNombre", primerNombre);
                    cmd.Parameters.AddWithValue("primerApellido", primerApellido);
                    cmd.Parameters.AddWithValue("telefono", Telefono ?? "");
                    cmd.Parameters.AddWithValue("direccion", Direccion ?? "");

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

        public bool inactivarUsuario(int Id, string primerNombre, string primerApellido, string Telefono, string Direccion)
        {
            bool rpt;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_inactivar_usuario", conexion);
                    cmd.Parameters.AddWithValue("id", Id);
                    cmd.Parameters.AddWithValue("primerNombre", primerNombre);
                    cmd.Parameters.AddWithValue("primerApellido", primerApellido);
                    cmd.Parameters.AddWithValue("telefono", Telefono ?? "");
                    cmd.Parameters.AddWithValue("direccion", Direccion ?? "");

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

        public bool suspenderUsuario(int Id, DateTime fechaSuspension, string motivoSuspension)
        {
            bool rpt;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_suspender_usuario", conexion);
                    cmd.Parameters.AddWithValue("id", Id);
                    cmd.Parameters.AddWithValue("fechaCrea", fechaSuspension);
                    cmd.Parameters.AddWithValue("motivoSuspension", motivoSuspension);

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
