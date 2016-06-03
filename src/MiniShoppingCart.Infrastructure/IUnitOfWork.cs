namespace MiniShoppingCart.Infrastructure
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public interface IUnitOfWork
    {
        int SaveChanges();
        DbSet<Customer> Customers { get; set; }
        void BeginTransaction();
        void CommitTransaction();
    }
}