using OrbitalOptics.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.Application.UseCases.Queries.Images
{
    public interface IGetImagesQuery : IQuery<PagedResponseDTO<ImageDTO>, GetImageDTO>
    {

    }
}
