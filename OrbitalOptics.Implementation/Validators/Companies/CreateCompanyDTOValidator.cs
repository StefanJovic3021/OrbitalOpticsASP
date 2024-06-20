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
    public class CreateCompanyDTOValidator : AbstractValidator<CreateCompanyDTO>
    {
        public CreateCompanyDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotEmpty()
                                .Must(x => !context.Companies.Any(c => c.Name == x))
                                .WithMessage("Company with this name already exists.");
        }
    }
}
