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
    public class EfUpdateUserAccessCommand : EfUseCase, IUpdateUseAccessCommand
    {
        private UpdateUserAccessDTOValidator _validator;
        public EfUpdateUserAccessCommand(OrbitalOpticsContext context, UpdateUserAccessDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Update user access command";

        public void Execute(UpdateUserAccessDTO data)
        {
            _validator.ValidateAndThrow(data);

            var userUseCases = Context.UserUseCases.Where(x => x.UserId == data.UserId)
                                                   .ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            Context.UserUseCases.AddRange(data.UseCaseIds.Select(x =>
            new Domain.UserUseCase
            {
                UserId = data.UserId,
                UseCaseId = x
            }));

            Context.SaveChanges();
        }
    }
}
