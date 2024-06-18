using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class Image : Entity
    {
        public string Path { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
