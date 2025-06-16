namespace Task1.Domain.Entities{
    public class Item
    {
        public int Id { get; set; } //Μοναδικό αναγνωριστικό για κάθε item (Primary Key)

        public int OrderId { get; set; } //Σε ποιο order ανήκει αυτό το item (Foreign Key)

        public int ProductId { get; set; } //Ποιο product παραγγέλθηκε (Foreign Key)

        public int Quantity { get; set; } //Ποσότητα products που παραγγέλθηκαν

        //πλοήγηση
        public Order Order { get; set; } = null!; //Η σχέση με τον order.
        public Product Product { get; set; } = null!; //Η σχέση με τον product.
    }
}