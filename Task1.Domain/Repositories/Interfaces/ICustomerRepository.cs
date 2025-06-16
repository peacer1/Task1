using Task1.Domain.Entities;

namespace Task1.Domain.Repositories.Interfaces{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id); //Βρίσκει έναν customer με βάση το id
        Task<IEnumerable<Customer>> GetAllAsync(); //Επιστρέφει όλους τους customers
        Task AddAsync(Customer customer); //Προσθέτει νέο customer
        void Update(Customer customer); //Ενημερώνει υπάρχοντα customer
        void Delete(Customer customer); //Διαγράφει customer
    }
}