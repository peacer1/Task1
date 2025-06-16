using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Products{
    public class CreateProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork; //Μέσω του UnitOfWork έχουμε πρόσβαση στα repositories

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Δημιουργούμε νέο αντικείμενο product από τα δεδομένα της εντολής
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };

            //Προσθέτουμε το Product μέσω του ProductRepository
            await _unitOfWork.Products.AddAsync(product);

            //Αποθηκεύουμε τις αλλαγές στη βάση μέσω του DbContext (μέσα από το UnitOfWork)
            await _unitOfWork.SaveChangesAsync();

            // Επιστρέφουμε το Id του νέου πελάτη
            return product.Id;
        }
    }
}