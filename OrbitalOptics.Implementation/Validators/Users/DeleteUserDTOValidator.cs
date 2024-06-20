using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.Validators.Users
{
    public class DeleteUserDTOValidator : AbstractValidator<DeleteUserDTO>
    {
        public DeleteUserDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty()
                              .Must(x => context.Users.Any(c => c.Id == x && c.IsActive == true))
                              .WithMessage("User not found.");
        }
    }
}
