using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Products
{
    public class GetProductByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να φέρουμε το product με το αντίστοιχο ID
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            //Επιστρέφουμε το product (ή null αν δεν υπάρχει)
            return product;
        }
    }
}
