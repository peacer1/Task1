using MediatR;

namespace Task1.Application.Commands.Orders{
    
    public class DeleteOrderCommand : IRequest<bool> // Επιστρέφει true αν πέτυχε, false αν όχι
    {
        public int Id { get; set; } //Το ID του product που θέλουμε να διαγράψουμε
    }
}
