using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Orders{

    public class UpdateOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            //Βρίσκουμε το order με το Id
            var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);

            if (order == null)
            {
                //Αν δεν βρέθηκε, δεν μπορούμε να τον ενημερώσουμε
                return false;
            }

            order.CustomerId = request.CustomerId;
            order.OrderDate = request.OrderDate;
            order.TotalPrice = 0;
            order.Items.Clear(); //Αφαιρούμε τα παλιά items


            //Δημιουργία Items για το Order
            foreach (var itemDto in request.Items)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);
                if (product == null)
                    continue;

                var item = new Item
                {
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity,
                    Product = product
                };

                order.TotalPrice += product.Price * itemDto.Quantity;

                order.Items.Add(item);
            }

            _unitOfWork.Orders.Update(order);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
