using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Categories;
using OrbitalOptics.Application.UseCases.Queries.Categories;
using OrbitalOptics.Application.UseCases.Queries.Companies;
using OrbitalOptics.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrbitalOptics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public CategoriesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // POST api/<CategoriesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDTO dto, [FromServices] ICreateCategoryCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // DELETE api/<CategoriesController>?Id=<CategoryId>
        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteCategoryDTO dto, [FromServices] IDeleteCategoryCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // PUT api/<CategoriesController>
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCategoryDTO dto, [FromServices] IUpdateCategoryCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // GET api/<CategoriesController>?Keyword=<CategoryName>[&PerPage=<int>&Page=<int>]
        [HttpGet]
        public IActionResult Get([FromQuery] GetCategoryDTO search, [FromServices] IGetCategoriesQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
    }
}
