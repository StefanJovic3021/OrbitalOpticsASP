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
    public class EfUpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        private UpdateCategoryDTOValidator _validator;
        public EfUpdateCategoryCommand(OrbitalOpticsContext context, UpdateCategoryDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Update category command";

        public void Execute(UpdateCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);
            var categoryToCreate = Context.Categories.Where(x => x.Id == data.Id).FirstOrDefault();
            categoryToCreate.Name = data.Name;
            Context.SaveChanges();
        }
    }
}
