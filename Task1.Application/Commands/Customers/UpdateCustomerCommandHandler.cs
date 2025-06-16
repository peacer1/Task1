using MediatR;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Customers
{
    public class UpdateCustomerCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            //Βρίσκουμε τον customer με το Id
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);

            if (customer == null)
            {
                //Αν δεν βρέθηκε, δεν μπορούμε να τον ενημερώσουμε
                return false;
            }

            //Ενημερώνουμε τα πεδία με τα νέα δεδομένα
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Address = request.Address;
            customer.PostalCode = request.PostalCode;

            //Καλούμε το repository για να τον ενημερώσουμε
            _unitOfWork.Customers.Update(customer);

            //Αποθηκεύουμε τις αλλαγές στη βάση
            await _unitOfWork.SaveChangesAsync();

            return true; //Επιστρέφουμε επιτυχία
        }
    }
}
