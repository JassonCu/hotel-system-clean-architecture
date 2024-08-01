using Hotel.UseCases.Employees.Queries.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListEmployees()
        {
            var response = await _mediator.Send(new GetAllEmployeeQuery());

            return Ok(response);
        }
    }
}
