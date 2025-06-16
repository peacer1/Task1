using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Orders
{
    public class GetOrdersByCustomerIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrdersByCustomerIdQuery, IEnumerable<Order>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Order>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να φέρουμε το order με το αντίστοιχο ID
            var orders = await _unitOfWork.Orders.GetOrdersByCustomerIdAsync(request.CustomerId);

            //Επιστρέφουμε το order (ή null αν δεν υπάρχει)
            return orders;
        }
    }
}
