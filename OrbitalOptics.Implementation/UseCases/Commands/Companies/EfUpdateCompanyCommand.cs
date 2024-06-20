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
    public class EfUpdateCompanyCommand : EfUseCase, IUpdateCompanyCommand
    {
        UpdateCompanyDTOValidator _validator;
        public EfUpdateCompanyCommand(OrbitalOpticsContext context, UpdateCompanyDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Update company command";

        public void Execute(UpdateCompanyDTO data)
        {
            _validator.ValidateAndThrow(data);
            var companyToUpdate = Context.Companies.Where(x => x.Id == data.Id).FirstOrDefault();
            companyToUpdate.Name = data.Name;
            Context.SaveChanges();
        }
    }
}
