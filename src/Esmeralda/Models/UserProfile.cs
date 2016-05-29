using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser AplicationUser { get; set; }
        public ICollection<UserProfileCreditCard> UserProfileCreditCards { get; set; }
    }
}
