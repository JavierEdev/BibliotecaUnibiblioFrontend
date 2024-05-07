using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaUnibiblioMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El campo ususario es requerido")]
        public string usuario {  get; set; }
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        public string password { get; set; }
    }
}
