namespace MiniShoppingCart.Infrastructure
{
    using System;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }

        public DataContext(DbContextOptions options = null) : base(options)
        {
        }
        
        public void BeginTransaction()
        {
            this.Database.BeginTransaction();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public void CommitTransaction()
        {
            this.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            this.Database.RollbackTransaction();
        }
    }
}
