using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;
using Task1.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Task1.Infrastructure.Repositories{

    //Κλάση που υλοποιεί το ICustomerRepository interface του Domain
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        private readonly AppDbContext _context = context;

        //Βρίσκει customer με βάση το ID
        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        //Επιστρέφει όλους τους customers
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        //Δημιουργεί νέο customer
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        //Ενημερώνει έναν customer
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        //Διαγράφει έναν customer
        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

    }
}