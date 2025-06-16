using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Customers{
    public class CreateCustomerCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork; //Μέσω του UnitOfWork έχουμε πρόσβαση στα repositories

        //Αυτό εκτελείται όταν ο MediatR λάβει το CreateCustomerCommand
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            //Δημιουργούμε νέο αντικείμενο customer από τα δεδομένα της εντολής
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PostalCode = request.PostalCode
            };

            //Προσθέτουμε τον customer μέσω του CustomerRepository
            await _unitOfWork.Customers.AddAsync(customer);

            //Αποθηκεύουμε τις αλλαγές στη βάση μέσω του DbContext (μέσα από το UnitOfWork)
            await _unitOfWork.SaveChangesAsync();

            // Επιστρέφουμε το Id του νέου πελάτη
            return customer.Id;
        }
    }
}