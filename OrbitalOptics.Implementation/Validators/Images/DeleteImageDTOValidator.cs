using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.Validators.Images
{
    public class DeleteImageDTOValidator : AbstractValidator<DeleteImageDTO>
    {
        public DeleteImageDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty()
                              .Must(x => context.Images.Any(p => p.Id == x && p.IsActive == true))
                              .WithMessage("Image not found.");
        }
    }
}
