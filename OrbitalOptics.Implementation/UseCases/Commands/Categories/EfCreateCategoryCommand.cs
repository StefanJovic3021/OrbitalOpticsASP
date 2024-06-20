using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Categories;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Domain;
using OrbitalOptics.Implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private CreateCategoryDTOValidator _validator;
        public EfCreateCategoryCommand(OrbitalOpticsContext context, CreateCategoryDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Create category command";

        public void Execute(CreateCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);

            Category category = new()
            {
                Name = data.Name
            };

            Context.Categories.Add(category);

            Context.SaveChanges();
        }
    }
}
