using MediatR;

namespace Task1.Application.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest<bool> //Επιστρέφει true/false αν η διαγραφή πέτυχε
    {
        public int Id { get; set; } //Το Id του customer που θέλουμε να διαγράψουμε
        
    }
}