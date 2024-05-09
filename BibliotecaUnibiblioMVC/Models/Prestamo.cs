namespace BibliotecaUnibiblioMVC.Models
{
    public class Prestamo
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public DateTime fechaRetorno { get; set; }
        public string correoUsuario { get; set; }
        public int idPrestamo { get; set; }
    }
}
