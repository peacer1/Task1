using MediatR;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Customers
{
    public class DeleteCustomerCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            //Βρίσκουμε τον customer με το Id
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);

            if (customer == null)
            {
                //Αν δεν βρέθηκε, δεν μπορούμε να τον διαγράψουμε
                return false;
            }

            //Καλούμε το repository για να τον διαγράψουμε
            _unitOfWork.Customers.Delete(customer);

            //Αποθηκεύουμε τις αλλαγές στη βάση
            await _unitOfWork.SaveChangesAsync();

            return true; //Επιστρέφουμε επιτυχία
        }
    }
}