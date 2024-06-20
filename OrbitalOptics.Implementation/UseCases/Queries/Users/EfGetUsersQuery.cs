using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Queries.Users;
using OrbitalOptics.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Implementation.UseCases.Queries.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(OrbitalOpticsContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Get users query";

        public PagedResponseDTO<UserDTO> Execute(GetUserDTO search)
        {
            var query = Context.Users.AsQueryable().Where(x => x.IsActive == true);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Email.ToLower().Contains(search.Keyword.ToLower()));
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponseDTO<UserDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new UserDTO
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    ImagePath = x.Image.Path
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
