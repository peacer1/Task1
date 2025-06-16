using Task1.Domain.Entities;
using Task1.Domain.Repositories.Interfaces;
using Task1.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Task1.Infrastructure.Repositories{

    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        private readonly AppDbContext _context = context;

        //Επιστρέφει ένα order με βάση το id. Περιλαμβάνει και τα items του order και τα products κάθε item
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items) //Φέρνει μαζί και τα items
                .ThenInclude(i => i.Product) //Φέρνει μαζί και τα products των items
                .FirstOrDefaultAsync(o => o.Id == id); //Φέρνει το πρώτο (ή null)
        }

        //Επιστρέφει όλα τα orders μαζί με items και products
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();
        }

        //Φέρνει όλα τα orders ενός συγκεκριμένου customer
        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();
        }

        //Επιστρέφει όλα τα orders από μια ημερομηνία και μετά
        public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime fromDate)
        {
            return await _context.Orders
                .Where(o => o.OrderDate >= fromDate)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();
        }

        //Προσθέτει νέο order στη βάση
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        //Ενημερώνει ένα order
        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        //Διαγράφει ένα order
        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }

    }
}