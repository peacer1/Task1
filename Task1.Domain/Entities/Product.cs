namespace Task1.Domain.Entities{
    public class Product
    {
        public int Id { get; set; } //Μοναδικό αναγνωριστικό για κάθε product (Primary Key)

        public string Name { get; set; } = string.Empty; //Το όνομα του product

        public decimal Price { get; set; } = 0m; //Η τιμή του product
    }
}