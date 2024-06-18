using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class Cart : Entity
    {
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<CartPrice> CartPrices { get; set; } = new HashSet<CartPrice>();
    }
}
