using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Images;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Domain;
using OrbitalOptics.Implementation.Validators.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Images
{
    public class EfCreateImageCommand : EfUseCase, ICreateImageCommand
    {
        private CreateImageDTOValidator _validator;
        public EfCreateImageCommand(OrbitalOpticsContext context, CreateImageDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Create image command";

        public void Execute(CreateImageDTO data)
        {
            _validator.ValidateAndThrow(data);

            string extension = Path.GetExtension(data.Image.FileName);
            string img = Guid.NewGuid().ToString() + extension;

            string tempFile = Path.Combine("wwwroot", "temp", img);
            using (var fs = new FileStream(tempFile, FileMode.Create))
            {
                data.Image.CopyTo(fs);
            }

            string destinationFile = Path.Combine("wwwroot", "images", img);
            File.Move(tempFile, destinationFile);

            Image newImage = new Image
            {
                Path = img
            };

            Context.Images.Add(newImage);
            Context.SaveChanges();
        }
    }
}
