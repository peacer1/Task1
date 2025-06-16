using MediatR;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Products
{
    public class DeleteProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            //Βρίσκουμε το product με το Id
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (product == null)
            {
                //Αν δεν βρέθηκε, δεν μπορούμε να τον διαγράψουμε
                return false;
            }

            //Καλούμε το repository για να τον διαγράψουμε
            _unitOfWork.Products.Delete(product);

            //Αποθηκεύουμε τις αλλαγές στη βάση
            await _unitOfWork.SaveChangesAsync();

            return true; //Επιστρέφουμε επιτυχία
        }
    }
}