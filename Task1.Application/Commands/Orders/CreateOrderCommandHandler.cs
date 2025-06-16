using MediatR;
using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;

namespace Task1.Application.Commands.Orders{

    public class CreateOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            //Φέρνουμε τον πελάτη
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer == null){
                throw new Exception("Customer not found");
            }
                

            //Δημιουργία Order
            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate,
                TotalPrice = 0m,
            };

            //Δημιουργία Items για το Order
            foreach (var itemDto in request.Items)
            {
                //Φέρνουμε το product για να διαβάσουμε την τιμή του
                var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);

                if (product == null)
                    continue;

                var item = new Item
                {
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity,
                    Product = product
                };

                //Υπολογισμός τιμής
                order.TotalPrice += product.Price * itemDto.Quantity;

                order.Items.Add(item); //Το προσθέτουμε στο order
            }

            customer.TotalPrice += order.TotalPrice;
            _unitOfWork.Customers.Update(customer);

            await _unitOfWork.Orders.AddAsync(order);

            await _unitOfWork.SaveChangesAsync();

            return order.Id;
        }
    }
}
