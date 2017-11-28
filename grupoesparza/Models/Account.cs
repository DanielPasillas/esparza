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
        //
    }
}