using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Usuario Incorrecto")]
        public string UserName { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña Incorrecta")]
        public string Password { get; set; }


    }
}
