using MediatR;

namespace Task1.Application.Commands.Customers
{
    public class UpdateCustomerCommand : IRequest<bool> //Επιστρέφει true/false αν η ενημέρωση πέτυχε
    {
        public int Id { get; set; } //Το Id του customer που θέλουμε να ενημερώσουμε
        public string FirstName { get; set; } = string.Empty; //Νέο μικρό όνομα
        public string LastName { get; set; } = string.Empty; //Νέο επώνυμο
        public string Address { get; set; } = string.Empty; //Νέα διεύθυνση
        public string PostalCode { get; set; } = string.Empty; //Νέος ταχυδρομικός κώδικας
    }
}
