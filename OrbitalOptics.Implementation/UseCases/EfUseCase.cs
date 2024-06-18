using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly OrbitalOpticsContext _context;

        protected EfUseCase(OrbitalOpticsContext context)
        {
            _context = context;
        }

        protected OrbitalOpticsContext Context => _context;
    }
}
