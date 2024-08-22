using Hotel.Interface.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IMediator mediator, IEmployeesRepository employeesRepository)
        {
            _mediator = mediator;
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeesRepository.ListEmployees();
                return Ok(new { isSuccess = true, data = employees });
            }
            catch (Exception ex)
            {
                // Maneja la excepción, tal vez loguearla
                return StatusCode(500, new { isSuccess = false, message = ex.Message });
            }
        }
    }
}
