using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class RegisterAdminViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "Correo electronico requerido")]
        [EmailAddress(ErrorMessage = "Correo no valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña requerida")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener como minimo 6 caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmación de contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña no coincide")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(32, ErrorMessage = "El nombre debe contener como maximo 32 caracteres")]
        public string UserName { get; set; }
        
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Dirección requerida")]
        [StringLength(255,ErrorMessage = "La direccion debe contener como minimo 5 caracteres", MinimumLength = 5)]
        public string Address { get; set; }
        
    }
}
