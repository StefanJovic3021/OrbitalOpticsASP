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
    public class EfUpdateImageCommand : EfUseCase, IUpdateImageCommand
    {
        private UpdateImageDTOValidator _validator;
        public EfUpdateImageCommand(OrbitalOpticsContext context, UpdateImageDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Update image command";

        public void Execute(UpdateImageDTO data)
        {
            // This update request is actually an insert but i preserves old profile pictures
            _validator.ValidateAndThrow(data);

            // Inserting new file
            string extension = Path.GetExtension(data.Image.FileName);
            string img = Guid.NewGuid().ToString() + extension;

            string tempFile = Path.Combine("wwwroot", "temp", img);
            using (var fs = new FileStream(tempFile, FileMode.Create))
            {
                data.Image.CopyTo(fs);
            }

            string destinationFile = Path.Combine("wwwroot", "images", img);
            File.Move(tempFile, destinationFile);

            // Finding old user and replacing his image with new one
            // This way I can preserve his old pictures and also have them in db
            User user = Context.Users.Where(x => x.ImageId == data.Id).FirstOrDefault();

            Image newImage = new Image
            {
                Path = img
            };

            // Inserting new picture in db along with updating user's ImageId
            Context.Images.Add(newImage);
            user.Image = newImage;

            // Soft deleting old picture
            var imageToSoftDelete = Context.Images.Where(x => x.Id == data.Id).FirstOrDefault();
            imageToSoftDelete.IsActive = false;

            Context.SaveChanges();
        }
    }
}
