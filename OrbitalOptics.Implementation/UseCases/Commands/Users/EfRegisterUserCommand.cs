using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Users;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Domain;
using OrbitalOptics.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Users
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        public RegisterUserDTOValidator _validator;
        public EfRegisterUserCommand(OrbitalOpticsContext context, RegisterUserDTOValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;
        public string Name => "Register User Command";

        public void Execute(RegisterUserDTO data)
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

            Image profileImage = new Image
            {
                Path = img
            };

            User user = new User
            {
                Email = data.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Image = profileImage,
                Username = data.Username,
                UseCases = new List<UserUseCase>()
                {
                    // Default use cases for new user
                    new UserUseCase { UseCaseId = 2 }
                }
            };

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}
