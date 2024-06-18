using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class Product : NamedEntity
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Companyid { get; set; }
        public int ImageId { get; set; }

        public Category Category { get; set; }
        public Company Company { get; set; }
        public Image Image { get; set; }
        public Price Price { get; set; }
    }
}
