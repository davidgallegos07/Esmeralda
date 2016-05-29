using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Cal { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
