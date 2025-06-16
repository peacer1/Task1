using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Customers{
    
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        //Δεν χρειάζεται να έχει properties γιατί απλά ζητάει όλα τα δεδομένα
    }
}
