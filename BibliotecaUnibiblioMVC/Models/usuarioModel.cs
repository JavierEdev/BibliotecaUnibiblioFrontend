using System.ComponentModel.DataAnnotations;

namespace BibliotecaUnibiblioMVC.Models
{
    public class usuarioModel
    {
        [Required(ErrorMessage = "El campo de Primer Nombre es obligatorio")]
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        [Required(ErrorMessage = "El campo del Primer Apellido es obligatorio")]
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        [Required(ErrorMessage = "El campo DPI es obligatorio")]
        public string dpi { get; set; }
        public string telefono { get; set; }
        [Required(ErrorMessage = "El campo correo es obligatorio")]
        public string correo { get; set; }
        public string direccion {  get; set; }
        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string contrasena { get; set; }
        [Required(ErrorMessage = "El campo confirmar contraseña es obligatorio")]
        public string confirmarContrasena { get; set; }
        public int rol { get; set; }


    }
}
