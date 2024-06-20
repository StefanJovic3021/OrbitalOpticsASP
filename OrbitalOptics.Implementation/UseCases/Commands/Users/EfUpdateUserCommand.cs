using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Users;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Domain;
using OrbitalOptics.Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private UpdateUserDTOValidator _validator;
        public EfUpdateUserCommand(OrbitalOpticsContext context, UpdateUserDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Update user command";

        public void Execute(UpdateUserDTO data)
        {
            _validator.ValidateAndThrow(data);
            var userToUpdate = Context.Users.Where(x => x.Id == data.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(data.Username))
            {
                userToUpdate.Username = data.Username;
            }
            if (!string.IsNullOrEmpty(data.Password))
            {
                userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
            }
            if (data.Image != null)
            {
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
                userToUpdate.Image = newImage;

                // Soft deleting old picture
                var imageToSoftDelete = Context.Images.Where(x => x.Id == data.Id).FirstOrDefault();
                imageToSoftDelete.IsActive = false;
            }

            Context.SaveChanges();
        }
    }
}
