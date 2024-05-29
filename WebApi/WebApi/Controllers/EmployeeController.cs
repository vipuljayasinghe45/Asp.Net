using System.Threading;
using Application.Implementation.Command;
using Application.Implementation.Query;
using Azure.Core;
using Domain.entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            applicationDbContext = context;
        }

        [HttpGet]

        public async Task<IActionResult> Getemployee()
        {
            var result = await _mediator.Send(new GetAllEmployeeQuery());

            return Ok(result);
        }

        [HttpPost("createEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand createEmployee, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createEmployee, cancellationToken);

            return Ok(result);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmeployee updateEmeploye, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(updateEmeploye, cancellationToken);

            return Ok(result);

        }

        [HttpDelete("DeleteEmployee/{id}")]

        public async Task<IActionResult> DeleteTeacher(Guid id)

        {
            var Employee = await applicationDbContext.Employee.FindAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }
            else
            {
                applicationDbContext.Employee.Remove(Employee);
                await applicationDbContext.SaveChangesAsync();

                return Ok(Employee);
            }
        }


        [HttpGet("GetId/{id}")]
        public async Task<IActionResult> GetId(string id , CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetId(new Guid(id)), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }


    }

}
