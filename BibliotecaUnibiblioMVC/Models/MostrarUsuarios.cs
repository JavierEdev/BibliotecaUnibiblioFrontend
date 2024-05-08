namespace BibliotecaUnibiblioMVC.Models
{
    public class MostrarUsuarios
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string DPI { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string primerNombre { get; set; }
        public string primerApellido { get; set; }
        public DateTime? fechaSuspension { get; set; }
        public string? motivoSuspension { get; set; }

    }
}
