using System.Text;

namespace BibliotecaUnibiblioMVC.Datos
{
    public class Seguridad
    {
        //Encrepcion de cadenas en base 64
        public string EncriptarBase64(string _cadenaEncriptar)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(_cadenaEncriptar));
        }

        //Desencripcion de cadenas en base 64
        public string DesencriptarBase64(string _cadenaDesencriptar) {
            return Encoding.Unicode.GetString(Convert.FromBase64String(_cadenaDesencriptar));
        }
    }
}
