using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Customers{

    public class GetCustomerByIdQuery(int id) : IRequest<Customer?>
    {
        public int Id { get; set; } = id;
    }
}
