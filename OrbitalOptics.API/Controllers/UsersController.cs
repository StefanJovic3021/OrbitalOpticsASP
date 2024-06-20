using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Users;
using OrbitalOptics.Application.UseCases.Queries.Images;
using OrbitalOptics.Application.UseCases.Queries.Users;
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

        // DELETE api/<UsersController>?Id=<UserId>
        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteUserDTO dto, [FromServices] IDeleteUserCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // PUT api/<UsersController>/<UserId>/access
        [Authorize]
        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateUserAccessDTO dto, [FromServices] IUpdateUseAccessCommand command)
        {
            dto.UserId = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // PUT api/<UsersController>
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromForm] UpdateUserDTO dto, [FromServices] IUpdateUserCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // GET api/<UsersController>?Keyword=<keyword>[&PerPage=<int>&Page=<int>]
        [HttpGet]
        public IActionResult Get([FromQuery] GetUserDTO search, [FromServices] IGetUsersQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
    }
}
