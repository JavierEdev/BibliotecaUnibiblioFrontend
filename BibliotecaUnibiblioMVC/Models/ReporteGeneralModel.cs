namespace BibliotecaUnibiblioMVC.Models
{
    public class ReporteGeneralModel
    {
        public string NombreUsuario { get; set; }
        public string LibroPrestado { get; set; }
        public string nombre { get; set; }
        public DateTime? FechaCreacionDetalle { get; set; }
        public DateTime? FechaVencimientoPrestamo { get; set; }
        public int EstadoPrestamo { get; set; }

    }
}
