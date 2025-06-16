using MediatR;
using Microsoft.AspNetCore.Mvc; //φτιάχνουμε τον controller
using Task1.Application.Commands.Products;
using Task1.Application.Queries.Products;

namespace Task1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //Δημιουργεί endpoint π.χ. /api/customers
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        //GET: api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = newId }, null);
        }

        //PUT: api/products/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("Το ID στο URL δεν ταιριάζει με το ID στο σώμα.");

            var success = await _mediator.Send(command);

            if (!success)
                return NotFound();

            return NoContent();
        }

        //DELETE: api/products/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
