using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Orders{

    public class GetOrderByIdQuery(int id) : IRequest<Order?>
    {
        public int Id { get; set; } = id;
    }
}
