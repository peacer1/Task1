using MediatR;

namespace Task1.Application.Commands.Products{
    public class UpdateProductCommand : IRequest<bool> //Επιστρέφει true/false αν η ενημέρωση πέτυχε
    {
        public int Id { get; set; } //Το Id του product που θέλουμε να ενημερώσουμε
        public string Name { get; set; } = string.Empty; //Το όνομα του product
        public decimal Price { get; set; } = 0m; //Η τιμή του product
    }
}
