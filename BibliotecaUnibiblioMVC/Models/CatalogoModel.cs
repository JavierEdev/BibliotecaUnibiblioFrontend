using System.ComponentModel.DataAnnotations;

namespace BibliotecaUnibiblioMVC.Models
{
    public class CatalogoModel
    {
        public int idLibro { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string anioPublicacion { get; set; }
        public string grupoLibro { get; set; }
        public string enStock { get; set; }
        public string estado { get; set; }
        public string tipoIdentificador { get; set; }
        public string idArea { get; set; }

    }
}