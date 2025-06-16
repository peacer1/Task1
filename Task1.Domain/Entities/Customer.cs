namespace Task1.Domain.Entities{
    public class Customer
    {
        public int Id { get; set; } //Μοναδικό αναγνωριστικό για κάθε customer (Primary Key)

        public string FirstName { get; set; } = string.Empty; //Το μικρό όνομα του customer. string.Empty = αποτρέπει null values

        public string LastName { get; set; } = string.Empty; //Το επώνυμο του customer

        public string Address { get; set; } = string.Empty; //Η διεύθυνση του customer

        public string PostalCode { get; set; } = string.Empty; //Ο ταχυδρομικός κώδικας του customer

        //πλοήγηση
        public ICollection<Order> Orders { get; set; } = new List<Order>(); //Δηλώνει ότι ένας customer μπορεί να έχει πολλές παραγγελίες
                                                                            //ICollection<Order> = Λίστα orders
                                                                            //new List<Order>() = αποφεύγει null reference exceptions
        public decimal TotalPrice { get; set; }
        
    }
}