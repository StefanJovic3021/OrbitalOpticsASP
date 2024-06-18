using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ImageId { get; set; }

        public Image Image { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<UserUseCase> UseCases { get; set; }
    }
}
