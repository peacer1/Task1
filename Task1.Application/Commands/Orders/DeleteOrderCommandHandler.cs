using MediatR;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Orders{
    
    public class DeleteOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            //Βρίσκουμε το order με βάση το Id
            var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);

            if (order == null)
            {
                //Αν δεν υπάρχει, δεν μπορεί να διαγραφεί
                return false;
            }

            //Διαγράφουμε το order
            _unitOfWork.Orders.Delete(order);

            //Αποθηκεύουμε τις αλλαγές στη βάση
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
