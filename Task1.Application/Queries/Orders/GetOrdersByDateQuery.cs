using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Orders{

    public class GetOrdersByDateQuery(DateTime fromDate) : IRequest<IEnumerable<Order>>
    {
        public DateTime FromDate { get; set; } = fromDate;
    }
}
