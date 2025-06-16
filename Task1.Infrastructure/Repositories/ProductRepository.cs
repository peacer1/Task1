using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;
using Task1.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Task1.Infrastructure.Repositories{

    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        //Επιστρέφει ένα product με βάση το id.
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        //Επιστρέφει όλα τα products
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        //Δημιουργεί νέο product
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        //Ενημερώνει ένα product
        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        //Διαγράφει ένα product
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}