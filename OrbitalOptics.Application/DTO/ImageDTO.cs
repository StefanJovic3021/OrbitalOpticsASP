using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Application.DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }

    public class CreateImageDTO
    {
        public IFormFile Image { get; set; }
    }

    public class DeleteImageDTO
    {
        public int Id { get; set; }
    }

    public class UpdateImageDTO : DeleteImageDTO
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }

    public class GetImageDTO : PagedSearchDTO
    {
        public int? Id { get; set; }
        public string Keyword { get; set; }
    }
}
