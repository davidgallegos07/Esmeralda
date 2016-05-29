using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class UserProfileCreditCard
    {
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set;  }
    }
}
