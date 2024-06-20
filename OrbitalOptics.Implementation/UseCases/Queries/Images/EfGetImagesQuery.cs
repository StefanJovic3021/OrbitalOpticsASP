using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Queries.Images;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Queries.Images
{
    public class EfGetImagesQuery : EfUseCase, IGetImagesQuery
    {
        public EfGetImagesQuery(OrbitalOpticsContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Get images query";

        public PagedResponseDTO<ImageDTO> Execute(GetImageDTO search)
        {
            var query = Context.Images.AsQueryable().Where(x => x.IsActive == true);

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
            }

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.User.Username.ToLower().Contains(search.Keyword.ToLower()));
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponseDTO<ImageDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new ImageDTO
                {
                    Id = x.Id,
                    Path = x.Path
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
