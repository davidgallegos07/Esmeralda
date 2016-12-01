using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class MealViewModel
    {
        public int MealId { get; set; }
        [Display(Name = "Nombre de alimento")]
        [Required (ErrorMessage = "Nombre requerido")]
        public string MealName { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Descripción requerida")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Precio requerido")]
        public decimal Price { get; set; }

        [Display(Name = "Calorias")]
        [Required(ErrorMessage = "Calorias requeridas")]
        public decimal Cal { get; set; }

        [Display(Name = "Estimación")]
        [Required(ErrorMessage = "Estimación requeridas")]
        public decimal Estimation { get; set; }

        [Display(Name = "Categoria de alimento")]
        [Required(ErrorMessage = "Categoria requerida")]
        public int CategoryId { get; set; }
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
    }
    public class ChargeViewModel
    {

    }
}
