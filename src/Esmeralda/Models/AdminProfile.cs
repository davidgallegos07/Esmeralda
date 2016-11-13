using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class AdminProfile
    {
        public int AdminProfileId { get; set; }
        public string ApplicationUserId { get; set; }
        public string ImageUrl { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
