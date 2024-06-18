using Microsoft.AspNetCore.Mvc;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Users;
using OrbitalOptics.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrbitalOptics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UsersController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromForm] RegisterUserDTO dto, [FromServices] IRegisterUserCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }
    }
}
