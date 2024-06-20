using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Images;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Implementation.Validators.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Images
{
    public class EfDeleteImageCommand : EfUseCase, IDeleteImageCommand
    {
        private DeleteImageDTOValidator _validator;
        public EfDeleteImageCommand(OrbitalOpticsContext context, DeleteImageDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Delete image command";

        public void Execute(DeleteImageDTO data)
        {
            _validator.ValidateAndThrow(data);
            var imageToDelete = Context.Images.Where(x => x.Id == data.Id).FirstOrDefault();
            imageToDelete.IsActive = false;
            Context.SaveChanges();
        }
    }
}
