using MediatR;
using Microsoft.AspNetCore.Mvc; //φτιάχνουμε τον controller
using Task1.Application.Commands.Orders;
using Task1.Application.Queries.Orders;

namespace Task1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //Δημιουργεί endpoint π.χ. /api/orders
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }

        // GET /api/orders/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //GET: api/orders/customer/{customerId}
        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            var result = await _mediator.Send(new GetOrdersByCustomerIdQuery(customerId));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //GET /api/orders/date/{fromDate}
        [HttpGet("date/{fromDate:datetime}")]
        public async Task<IActionResult> GetOrdersByDate(DateTime fromDate)
        {
            var result = await _mediator.Send(new GetOrdersByDateQuery(fromDate));
            return Ok(result);
        }

        //POST: api/orders
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = newId }, null);
        }

        //PUT: api/orders/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.Id)
                return BadRequest("Το ID στο URL δεν ταιριάζει με το ID στο σώμα.");

            var success = await _mediator.Send(command);

            if (!success)
                return NotFound();

            return NoContent();
        }

        //DELETE: api/orders/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
