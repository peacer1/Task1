using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Orders{
    
    public class GetAllOrdersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να πάρουμε όλα τα orders
            var orders = await _unitOfWork.Orders.GetAllAsync();

            return orders;
        }
    }
}
