using MediatR;
using Task1.Domain.Entities;

namespace Task1.Application.Queries.Products{
    
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        //Δεν χρειάζεται να έχει properties γιατί απλά ζητάει όλα τα δεδομένα
    }
}
