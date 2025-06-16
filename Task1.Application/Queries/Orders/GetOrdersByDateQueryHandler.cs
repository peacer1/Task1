using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Orders
{
    public class GetOrdersByDateQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrdersByDateQuery, IEnumerable<Order>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Order>> Handle(GetOrdersByDateQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να φέρουμε τα orders με το αντίστοιχο ID
            var orders = await _unitOfWork.Orders.GetOrdersByDateAsync(request.FromDate);

            //Επιστρέφουμε το order (ή null αν δεν υπάρχει)
            return orders;
        }
    }
}
