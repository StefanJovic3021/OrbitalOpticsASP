using Microsoft.AspNetCore.Http;
using OrbitalOptics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }

    public class RegisterUserDTO
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
    }

    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
    }

    public class UpdateUserAccessDTO
    {
        public int UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }

    public class DeleteUserDTO
    {
        public int Id { get; set; }
    }

    public class GetUserDTO : PagedSearchDTO
    {
        public string Keyword { get; set; }
    }

}
