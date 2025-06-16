namespace Task1.Domain.Entities{
    public class Order
    {
        public int Id { get; set; } //Μοναδικό αναγνωριστικό για κάθε order (Primary Key)

        public int CustomerId { get; set; } //Σε ποιον customer ανήκει αυτό το order (Foreign Key)

        public DateTime OrderDate { get; set; } //Η ημερομηνία του order

        public decimal TotalPrice { get; set; } = 0m; //Η συνολική τιμή του order. Αρχικοποιείται σε 0.

        //πλοήγηση
        public Customer Customer { get; set; } = null!; //Η σχέση με τον customer. Το αντικείμενο αυτό δεν έχει τιμή τώρα, θα το δώσει το Entity Framework
        public ICollection<Item> Items { get; set; } = new List<Item>(); //Δηλώνει ότι ένα order μπορεί να έχει πολλά items
                                                                         //ICollection<Order> = Λίστα items
                                                                         //new List<Order>() = αποφεύγει null reference exceptions
    }
}