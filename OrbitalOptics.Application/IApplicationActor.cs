using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Username { get; }
        string Email { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
