using Task1.Domain.Entities;

namespace Task1.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id); //Βρίσκει product με βάση το id
        Task<IEnumerable<Product>> GetAllAsync(); //Επιστρέφει όλα τα products
        Task AddAsync(Product product); //Προσθέτει νέο product
        void Update(Product product); //Ενημερώνει υπάρχον product
        void Delete(Product product); //Διαγράφει product
    }
}