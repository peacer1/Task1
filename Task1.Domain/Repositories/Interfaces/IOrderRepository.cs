using Task1.Domain.Entities;

namespace Task1.Domain.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int id); //Βρίσκει order με βάση το id
        Task<IEnumerable<Order>> GetAllAsync(); //Επιστρέφει όλα τα orders
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId); //orders ενός συγκεκριμένου customer
        Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime fromDate); //orders από συγκεκριμένη ημερομηνία και μετά
        Task AddAsync(Order order); //Προσθέτει νέο order
        void Update(Order order); //Ενημερώνει υπάρχον order
        void Delete(Order order); //Διαγράφει order
    }
}