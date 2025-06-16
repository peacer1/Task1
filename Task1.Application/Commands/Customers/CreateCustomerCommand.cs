using MediatR;

namespace Task1.Application.Commands.Customers{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; } = string.Empty; //Το μικρό όνομα του customer
        public string LastName { get; set; } = string.Empty; //Το επώνυμο του customer
        public string Address { get; set; } = string.Empty; //Η διεύθυνση του customer
        public string PostalCode { get; set; } = string.Empty; //Ο ταχυδρομικός κώδικας του customer
    }
}
