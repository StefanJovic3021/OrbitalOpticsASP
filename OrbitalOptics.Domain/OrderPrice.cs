using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class OrderPrice : Entity
    {
        public int OrderId { get; set; }
        public int PriceId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Price Price { get; set; }
    }
}
