using MediatR;

namespace Task1.Application.Commands.Products
{
    public class DeleteProductCommand : IRequest<bool> //Επιστρέφει true/false αν η διαγραφή πέτυχε
    {
        public int Id { get; set; } //Το Id του product που θέλουμε να διαγράψουμε
        
    }
}