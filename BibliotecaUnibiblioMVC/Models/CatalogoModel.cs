using System.ComponentModel.DataAnnotations;

namespace BibliotecaUnibiblioMVC.Models
{
    public class CatalogoModel
    {
        public int idLibro { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public DateTime? anioPublicacion { get; set; }
        public int grupoLibro { get; set; }
        public int enStock { get; set; }
        public int estado { get; set; }
        public int  tipoIdentificador { get; set; }
        public int idArea { get; set; }

    }
}