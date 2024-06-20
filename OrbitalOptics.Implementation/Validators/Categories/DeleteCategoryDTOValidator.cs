using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.Validators.Categories
{
    public class DeleteCategoryDTOValidator : AbstractValidator<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty()
                              .Must(x => context.Categories.Any(c => c.Id == x && c.IsActive == true))
                              .WithMessage("Category not found.");
        }
    }
}
