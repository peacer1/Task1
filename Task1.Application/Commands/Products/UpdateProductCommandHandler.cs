using MediatR;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Products{
    public class UpdateProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //Βρίσκουμε το product με το Id
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (product == null)
            {
                //Αν δεν βρέθηκε, δεν μπορούμε να τον ενημερώσουμε
                return false;
            }

            //Ενημερώνουμε τα πεδία με τα νέα δεδομένα
            product.Name = request.Name;
            product.Price = request.Price;

            //Καλούμε το repository για να τον ενημερώσουμε
            _unitOfWork.Products.Update(product);

            //Αποθηκεύουμε τις αλλαγές στη βάση
            await _unitOfWork.SaveChangesAsync();

            return true; //Επιστρέφουμε επιτυχία
        }
    }
}
