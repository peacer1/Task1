using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Orders{
    
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
        //Δεν χρειάζεται να έχει properties γιατί απλά ζητάει όλα τα δεδομένα
    }
    
}
