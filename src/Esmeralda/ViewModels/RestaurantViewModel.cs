using Esmeralda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class RestaurantViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public AdminProfile AdminProfile { get; set; }
    }
}
