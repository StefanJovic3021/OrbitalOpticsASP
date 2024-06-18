using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class Company : NamedEntity
    {
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
