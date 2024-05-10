namespace BibliotecaUnibiblioMVC.Models
{
    public class ListadoPrestamos
    {
        public int idLibro {  get; set; }
        public string nombreLibro {  get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaFinalizacion { get; set; }
        public string correo { get; set; }
    }
}
