using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Customers{
    
    public class GetAllCustomersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να πάρουμε όλους τους customers
            var customers = await _unitOfWork.Customers.GetAllAsync();

            return customers;
        }
    }
}
