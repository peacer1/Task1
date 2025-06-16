using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Orders{

    public class GetOrdersByCustomerIdQuery(int customerId) : IRequest<IEnumerable<Order>>
    {
        public int CustomerId { get; set; } = customerId;
    }
}
