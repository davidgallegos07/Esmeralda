using Esmeralda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.ViewModels
{
    public class ManageDataViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        
    }
}
