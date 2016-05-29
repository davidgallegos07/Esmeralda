using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
        public int CardExpirtationMonth { get; set; }
        public int CardExpirationYear { get; set; }
        public int CVC { get; set; }
        public ICollection<UserProfileCreditCard> UserProfileCreditCards { get; set; }
    }
}
