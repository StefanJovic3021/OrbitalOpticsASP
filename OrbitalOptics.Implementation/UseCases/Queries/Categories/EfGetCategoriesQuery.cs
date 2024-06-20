using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Queries.Categories;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(OrbitalOpticsContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Get categories query";

        public PagedResponseDTO<CategoryDTO> Execute(GetCategoryDTO search)
        {
            var query = Context.Categories.AsQueryable().Where(x => x.IsActive == true);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponseDTO<CategoryDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
