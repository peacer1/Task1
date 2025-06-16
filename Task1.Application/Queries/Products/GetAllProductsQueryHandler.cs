using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Products{
    
    public class GetAllProductsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να πάρουμε όλα τα products
            var products = await _unitOfWork.Products.GetAllAsync();

            return products;
        }
    }
}
