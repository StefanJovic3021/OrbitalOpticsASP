using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
    }

    public class DeleteCategoryDTO
    {
        public int Id { get; set; }
    }

    public class UpdateCategoryDTO : CategoryDTO
    {
        // CategoryDTO has both name and id
    }

    public class GetCategoryDTO : PagedSearchDTO
    {
        public string Keyword { get; set; }
    }
}
