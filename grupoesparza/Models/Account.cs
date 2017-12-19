using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace grupoesparza.Models
{
    public class Account
    {
    }

    public class Login
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }

    public class Register
    {
        [Required]
        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string ApellidosUsuario { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoUsuario { get; set; }

        [Required]
        public long idUniversidad { get; set; }

        [Required]
        public long idCarrera { get; set; }

        [Required]
        public long idGrupo { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}