using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Companies;
using OrbitalOptics.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrbitalOptics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public CompaniesController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        // POST api/<CompaniesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateCompanyDTO dto, [FromServices] ICreateCompanyCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }
    }
}
