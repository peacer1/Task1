using MediatR;

namespace Task1.Application.Commands.Orders{
    
    public class CreateOrderCommand : IRequest<int>
    {
        public int CustomerId { get; set; } //Ο customer που κάνει την παραγγελία
        public DateTime OrderDate { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = []; //Τα products της παραγγελίας
    }

    //DTO για κάθε item της παραγγελίας
    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
