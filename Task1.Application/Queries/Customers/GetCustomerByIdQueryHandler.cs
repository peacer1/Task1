using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Queries.Customers
{
    public class GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            //Καλούμε το repository για να φέρουμε τον customer με το αντίστοιχο ID
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);

            //Επιστρέφουμε τον customer (ή null αν δεν υπάρχει)
            return customer;
        }
    }
}
