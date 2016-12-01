using Esmeralda.Configuration;
using Esmeralda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class MealBuyViewModel
    {
        public PaymentSettings PaymentSettings { get; set; }
        public Meal Meal { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
