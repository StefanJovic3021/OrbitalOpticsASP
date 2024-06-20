﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.Validators.Images
{
    public class UpdateImageDTOValidator : AbstractValidator<UpdateImageDTO>
    {
        public UpdateImageDTOValidator(OrbitalOpticsContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty()
                              .Must(x => context.Images.Any(i => i.Id == x && i.IsActive == true))
                              .WithMessage("Image not found.");

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
