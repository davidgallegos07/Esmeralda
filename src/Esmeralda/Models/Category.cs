using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int AdminProfileId { get; set; }
        public AdminProfile AdminProfile { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
