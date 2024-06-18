using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class Price : Entity
    {
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }

        public Product Product { get; set; }
        public ICollection<CartPrice> CartPrices { get; set; } = new HashSet<CartPrice>();
        public ICollection<OrderPrice> OrderPrices { get; set; } = new HashSet<OrderPrice>();
    }
}
