using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Categories;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        private DeleteCategoryDTOValidator _validator;
        public EfDeleteCategoryCommand(OrbitalOpticsContext context, DeleteCategoryDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Delete category command";

        public void Execute(DeleteCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);
            var categoryToDelete = Context.Categories.Where(x => x.Id == data.Id).FirstOrDefault();
            categoryToDelete.IsActive = false;
            Context.SaveChanges();
        }
    }
}
