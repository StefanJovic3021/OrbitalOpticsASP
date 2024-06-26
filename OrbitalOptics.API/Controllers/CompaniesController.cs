﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitalOptics.Application.DTO;
using OrbitalOptics.Application.UseCases.Commands.Companies;
using OrbitalOptics.Application.UseCases.Queries.Companies;
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

        // DELETE api/<CompaniesController>?Id=<CompanyId>
        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteCompanyDTO dto, [FromServices] IDeleteCompanyCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // PUT api/<CompaniesController>
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCompanyDTO dto, [FromServices] IUpdateCompanyCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

        // GET api/<CompaniesController>?Keyword=<CompanyName>[&PerPage=<int>&Page=<int>]
        [HttpGet]
        public IActionResult Get([FromQuery] GetCompanyDTO search, [FromServices] IGetCompaniesQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
    }
}
