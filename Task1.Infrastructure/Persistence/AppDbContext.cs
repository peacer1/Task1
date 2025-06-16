using Microsoft.EntityFrameworkCore;
using Task1.Domain.Entities;

namespace Task1.Infrastructure.Persistence{

    //ρυθμίσεις (options) για τη βάση δεδομένων
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; } //EF καταλαβαίνει ότι το DbSet<Customer> είναι πίνακας στη βάση.

        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}