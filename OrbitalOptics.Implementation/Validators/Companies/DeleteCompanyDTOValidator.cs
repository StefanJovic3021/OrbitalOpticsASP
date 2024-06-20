using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.Validators.Companies
{
    public class DeleteCompanyDTOValidator : AbstractValidator<DeleteCompanyDTO>
    {
        public DeleteCompanyDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty()
                              .Must(x => context.Companies.Any(c => c.Id == x && c.IsActive == true))
                              .WithMessage("Company not found.");
        }
    }
}
