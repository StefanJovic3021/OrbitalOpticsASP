using FluentValidation;
using Microsoft.AspNetCore.Http;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrbitalOptics.Implementation.Validators.Users
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email).NotEmpty()
                                 .EmailAddress()
                                 .Must(x => !context.Users.Any(u => u.Email == x))
                                 .WithMessage("Email is already in use.");

            /*******************************************************************
                1. Only contains alphanumeric characters, underscore and dot.
                2. Underscore and dot can't be at the end or start of a username 
                    (e.g _username / username_ / .username / username.).
                3. Underscore and dot can't be next to each other 
                    (e.g user_.name).
                4. Underscore or dot can't be used multiple times in a row 
                    (e.g user__name / user..name).
                5. Number of characters must be between 8 to 20.
            *******************************************************************/
            RuleFor(x => x.Username).NotEmpty()
                                    .Matches("^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                                    .WithMessage("Invalid username format.")
                                    .Must(x => !context.Users.Any(u => u.Username == x))
                                    .WithMessage("Username is already in use.");

            RuleFor(x => x.Password).NotEmpty()
                                    .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                                    .WithMessage("Invalid password format. Must contain minimum eight characters, at least one uppercase letter, one lowercase letter and one number.");

            RuleFor(x => x.Image).NotEmpty()
                                 .Must(ImageExtensionValidator)
                                 .WithMessage("Invalid image extension. Only .jpg (.jpeg) and .png extensions are allowed.");
        }

        private bool ImageExtensionValidator(IFormFile image)
        {
            string extension = Path.GetExtension(image.FileName);

            if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png")
            {
                return true;
            }

            return false;
        }
    }
}
