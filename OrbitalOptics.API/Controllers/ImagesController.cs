using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Categories;
using OrbitalOptics.Application.UseCases.Commands.Images;
using OrbitalOptics.Application.UseCases.Queries.Companies;
using OrbitalOptics.Application.UseCases.Queries.Images;
using OrbitalOptics.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrbitalOptics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;
        public ImagesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // POST api/<ImagesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] CreateImageDTO dto, [FromServices] ICreateImageCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // DELETE api/<ImagesController>?Id=<CategoryId>
        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteImageDTO dto, [FromServices] IDeleteImageCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // PUT api/<ImagesController>
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromForm] UpdateImageDTO dto, [FromServices] IUpdateImageCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // GET api/<ImagesController>?Id=<ImageId>&Keyword=<keyword>[&PerPage=<int>&Page=<int>]
        [HttpGet]
        public IActionResult Get([FromQuery] GetImageDTO search, [FromServices] IGetImagesQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
    }
}
