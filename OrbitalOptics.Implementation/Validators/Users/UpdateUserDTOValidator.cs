using FluentValidation;
using Microsoft.AspNetCore.Http;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.Validators.Users
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty()
                              .Must(x => context.Users.Any(u => u.Id == x && u.IsActive == true))
                              .WithMessage("User not found.");

            RuleFor(x => x.Username).Matches("^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                                    .WithMessage("Invalid username format.")
                                    .Must(x => !context.Users.Any(u => u.Username == x))
                                    .WithMessage("Username is already in use.");

            RuleFor(x => x.Password).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                                    .WithMessage("Invalid password format. Must contain minimum eight characters, at least one uppercase letter, one lowercase letter and one number.");

            RuleFor(x => x.Image).Must(ImageExtensionValidator)
                                 .WithMessage("Invalid image extension. Only .jpg (.jpeg) and .png extensions are allowed.");
        }

        private bool ImageExtensionValidator(IFormFile image)
        {
            if (image == null) return true;

            string extension = Path.GetExtension(image.FileName);

            if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png")
            {
                return true;
            }

            return false;
        }
    }
}
