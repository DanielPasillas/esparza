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
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        public long id_universidad { get; set; }

        [Required]
        public long id_carrera { get; set; }

        [Required]
        public long id_grupo { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int estatus_account { get; set; }

        public int estatus_active { get; set; }

        public DateTime fecha_registro { get; set; }

        public Register()
        {
            estatus_account = 1;
            estatus_active = 1;
            fecha_registro = DateTime.Now;
        }

    }
}