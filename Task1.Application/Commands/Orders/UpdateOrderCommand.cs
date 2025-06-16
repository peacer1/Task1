using MediatR;

namespace Task1.Application.Commands.Orders{
    
    public class UpdateOrderCommand : IRequest<bool> //Επιστρέφει true/false αν η ενημέρωση πέτυχε
    {
        public int CustomerId { get; set; } //Ο customer που κάνει την παραγγελία
        public int Id { get; set; } //Το Id του order που θέλουμε να ενημερώσουμε
        public DateTime OrderDate { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = []; //Τα products της παραγγελίας
        public int Quantity { get; internal set; }
    }

    //DTO για κάθε item της παραγγελίας
    public class UpdateOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
