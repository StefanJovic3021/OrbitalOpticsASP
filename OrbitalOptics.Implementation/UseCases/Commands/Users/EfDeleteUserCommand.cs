using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Users;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        private DeleteUserDTOValidator _validator;
        public EfDeleteUserCommand(OrbitalOpticsContext context, DeleteUserDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Delete user command";

        public void Execute(DeleteUserDTO data)
        {
            _validator.ValidateAndThrow(data);
            var userToDelete = Context.Users.Where(x => x.Id == data.Id).FirstOrDefault();
            userToDelete.IsActive = false;
            Context.SaveChanges();
        }
    }
}
