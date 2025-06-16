using Task1.Domain.Repositories.Interfaces;
using Task1.Infrastructure.Persistence;

namespace Task1.Infrastructure.Repositories
{
    public class UnitOfWork(
        AppDbContext context,
        ICustomerRepository customerRepository,
        IOrderRepository orderRepository,
        IProductRepository productRepository) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        //Repositories
        public ICustomerRepository Customers { get; } = customerRepository;
        public IOrderRepository Orders { get; } = orderRepository;
        public IProductRepository Products { get; } = productRepository;

        //Αποθηκεύει όλες τις αλλαγές στην DB
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
