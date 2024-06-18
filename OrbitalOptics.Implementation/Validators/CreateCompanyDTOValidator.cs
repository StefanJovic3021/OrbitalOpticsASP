using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.Validators
{
    public class CreateCompanyDTOValidator : AbstractValidator<CreateCompanyDTO>
    {
        public CreateCompanyDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
