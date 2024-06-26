﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Application.DTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateCompanyDTO
    {
        public string Name { get; set; }
    }

    public class DeleteCompanyDTO
    {
        public int Id { get; set; }
    }

    public class UpdateCompanyDTO : CompanyDTO
    {
        // CompanyDTO has both name and id
    }

    public class GetCompanyDTO : PagedSearchDTO
    {
        public string Keyword { get; set; }
    }
}
