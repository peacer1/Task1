using MediatR;
using Microsoft.AspNetCore.Mvc; //φτιάχνουμε τον controller
using Task1.Application.Commands.Customers;
using Task1.Application.Queries.Customers;

namespace Task1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //Δημιουργεί endpoint π.χ. /api/customers
    public class CustomersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }

        //GET: api/customers/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //POST: api/customers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = newId }, null);
        }

        //PUT: api/customers/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id)
                return BadRequest("Το ID στο URL δεν ταιριάζει με το ID στο σώμα.");

            var success = await _mediator.Send(command);

            if (!success)
                return NotFound();

            return NoContent();
        }

        //DELETE: api/customers/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
