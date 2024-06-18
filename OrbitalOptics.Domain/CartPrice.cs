using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class CartPrice : Entity
    {
        public int CartId { get; set; }
        public int PriceId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Price Price { get; set; }
    }
}
