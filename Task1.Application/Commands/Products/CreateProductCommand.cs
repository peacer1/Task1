using MediatR;

namespace Task1.Application.Commands.Products{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty; //Το όνομα του product
        public decimal Price { get; set; } = 0m; //Η τιμή του product
    }
}
