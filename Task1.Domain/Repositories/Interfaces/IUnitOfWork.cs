namespace Task1.Domain.Repositories.Interfaces{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; } //Repository για customer οντότητες

        IOrderRepository Orders { get; } //Repository για order οντότητες

        IProductRepository Products { get; } //Repository για product οντότητες

        Task<int> SaveChangesAsync(); //Αποθηκεύει όλες τις αλλαγές από τα repositories με ένα ενιαίο commit στη βάση
    }
}