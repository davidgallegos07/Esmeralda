using Esmeralda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre requerido")]
        public string Name { get; set; }
        //add
        public ICollection<Meal> Meals { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
