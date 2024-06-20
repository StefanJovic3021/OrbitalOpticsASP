using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Companies;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Implementation.Validators.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Companies
{
    public class EfDeleteCompanyCommand : EfUseCase, IDeleteCompanyCommand
    {
        private DeleteCompanyDTOValidator _validator;

        public EfDeleteCompanyCommand(OrbitalOpticsContext context, DeleteCompanyDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Delete company command";

        public void Execute(DeleteCompanyDTO data)
        {
            _validator.ValidateAndThrow(data);
            var companyToDelete = Context.Companies.Where(x => x.Id == data.Id).FirstOrDefault();
            companyToDelete.IsActive = false;
            Context.SaveChanges();
        }
    }
}
