using OrbitalOptics.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Application.UseCases.Queries.Companies
{
    public interface IGetCompaniesQuery : IQuery<PagedResponseDTO<CompanyDTO>, GetCompanyDTO>
    {

    }
}
