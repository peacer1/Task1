using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Orders
{
    public class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrderByIdQuery, Order?>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να φέρουμε το order με το αντίστοιχο ID
            var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);

            //Επιστρέφουμε το order (ή null αν δεν υπάρχει)
            return order;
        }
    }
}
