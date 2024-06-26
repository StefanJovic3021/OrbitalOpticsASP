﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public User User { get; set; }
        public ICollection<OrderPrice> OrderPrices { get; set; } = new HashSet<OrderPrice>();
    }
}
