using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Products{

    public class GetProductByIdQuery(int id) : IRequest<Product?>
    {
        public int Id { get; set; } = id;
    }
}
