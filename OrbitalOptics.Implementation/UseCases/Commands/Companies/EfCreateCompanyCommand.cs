using FluentValidation;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Companies;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Domain;
using OrbitalOptics.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Commands.Companies
{
    public class EfCreateCompanyCommand : EfUseCase, ICreateCompanyCommand
    {
        private CreateCompanyDTOValidator _validator;

        public EfCreateCompanyCommand(OrbitalOpticsContext context, CreateCompanyDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Create company command";

        public void Execute(CreateCompanyDTO data)
        {
            _validator.ValidateAndThrow(data);

            Company company = new()
            {
                Name = data.Name
            };

            Context.Companies.Add(company);

            Context.SaveChanges();
        }
    }
}
