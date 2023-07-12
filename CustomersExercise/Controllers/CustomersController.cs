using CustomersExercise.Application.Commands.Customer.CreateCustomer;
using CustomersExercise.Application.Commands.Customer.DeleteCustomer;
using CustomersExercise.Application.Dto.Customer;
using CustomersExercise.Application.Queries.Customer.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomersExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns list of all customers
        /// </summary>    
        [HttpGet]
        [ProducesResponseType(typeof(List<GetCustomerDto>), 200)]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllCustomersQuery(), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Create new customers
        /// <param name="customer">CreateCustomerDto object</param>
        /// </summary>    
        [HttpPost]
        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto customer, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateCustomerCommand() { CreateCustomerDto = customer }, cancellationToken);
            return Created("", response.Id);
        }

        /// <summary>
        /// Delete customer with selected id
        /// <param name="id">Id of customer to delete</param>
        /// </summary>  
        [HttpDelete("/{id}")]
        [ProducesResponseType(typeof(void), 204)]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteCustomerCommand() { Id = id }, cancellationToken);
            if (!response.IsSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}