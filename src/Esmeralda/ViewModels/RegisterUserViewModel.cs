using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class RegisterUserViewModel
    {
        public RegisterUserViewModel()
        {
            AllMonths = new List<SelectListItem>() {

            //AllMonths.Add(new SelectListItem() { Text = "Enero", Value = "1" });
            //AllMonths.Add(new SelectListItem() { Text = "Febrero", Value = "2" });
            new SelectListItem() { Text = "1", Value = "1" },
            new SelectListItem() { Text = "2", Value = "2" },
            new SelectListItem() { Text = "3", Value = "3" },
            new SelectListItem() { Text = "5", Value = "4" },
            new SelectListItem() { Text = "5", Value = "5" },
            new SelectListItem() { Text = "6", Value = "6" },
            new SelectListItem() { Text = "7", Value = "7" },
            new SelectListItem() { Text = "8", Value = "8" },
            new SelectListItem() { Text = "9", Value = "9" },
            new SelectListItem() { Text = "10", Value = "10" },
            new SelectListItem() { Text = "11", Value = "11" },
            new SelectListItem() { Text = "12", Value = "12" },


            };
            AllYears = new List<SelectListItem>()
            {
                new SelectListItem() { Text="2016", Value="2016" },
                new SelectListItem() { Text="2017", Value="2017" },
                new SelectListItem() { Text="2018", Value="2018" },
                new SelectListItem() { Text="2019", Value="2019" },
                new SelectListItem() { Text="2020", Value="2020" },
                new SelectListItem() { Text="2021", Value="2021" },
                new SelectListItem() { Text="2022", Value="2022" },
                new SelectListItem() { Text="2023", Value="2023" },
                new SelectListItem() { Text="2024", Value="2024" },
                new SelectListItem() { Text="2025", Value="2025" },
                new SelectListItem() { Text="2026", Value="2026" },
                new SelectListItem() { Text="2027", Value="2027" },
                new SelectListItem() { Text="2028", Value="2028" },
                new SelectListItem() { Text="2029", Value="2029" },
                new SelectListItem() { Text="2030", Value="2030" },
                new SelectListItem() { Text="2031", Value="2031" },
                new SelectListItem() { Text="2032", Value="2032" },
                new SelectListItem() { Text="2033", Value="2033" },
                new SelectListItem() { Text="2034", Value="2034" },
                new SelectListItem() { Text="2035", Value="2035" },
            };

        }
       
        public List<SelectListItem> AllMonths { get; private set; }
        public List<SelectListItem> AllYears { get; private set; }
        public int Id { get; set; }
        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "Correo electronico requerido")]
        [EmailAddress(ErrorMessage = "Correo no valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required (ErrorMessage = "La contraseña es requerida")]        
        [StringLength (100, ErrorMessage = "La contraseña debe tener como minimo 6 caracteres", MinimumLength = 6)]
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

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Apellido Requerido")]
        [StringLength(32, ErrorMessage = "El Apellido debe contener como maximo 32 caracteres")]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber,ErrorMessage = "Solo Numero")]
        [Display(Name = "Tarjeta credito/debito")]
        [StringLength(16, ErrorMessage = "Tarjeta no valida")]
        [Required(ErrorMessage = "Numero requerido")]
        public string CardNumber { get; set; }

        [Display(Name = "Mes de Expiracion")]
        [Required(ErrorMessage = "Mes requerido")]
        [Range(1,12,ErrorMessage = "Mes no valido")]
        public int CardExpirationMonth { get; set; }


        [Display(Name = "Año de Expiracion")]
        [Required(ErrorMessage = "Año requerido")]
        [Range(2016,2035, ErrorMessage = "Año no valido")]
        public int CardExpirationYear { get; set; }


        [Display(Name = "Codigo de seguridad")]
        [Required(ErrorMessage = "Codigo de seguiridad requerido")]
        [DataType(DataType.PhoneNumber,ErrorMessage = "Solo numeros")]
        public int CVC { get; set; }


    }
}
