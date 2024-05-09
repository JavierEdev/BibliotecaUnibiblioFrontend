namespace BibliotecaUnibiblioMVC.Models
{
    public class DeudorModel
    {
        public string PrimerNombreUsuario { get; set; }
        public string SegundoNombreUsuario { get; set; }
        public string PrimerApellidoUsuario { get; set; }
        public string SegundoApellidoUsuario { get; set; }
        public long DPIUsuario { get; set; }
        public long TelefonoUsuario { get; set; }
        public string CorreoElectronicoUsuario { get; set; }
        public string DireccionUsuario { get; set; }
        public string NombreLibro { get; set; }
        public int EnStockLibro { get; set; }
        public DateTime? FechaInicioPrestamo { get; set; }
        public DateTime? FechaDevolucionPrestamo { get; set; }
    }
}
