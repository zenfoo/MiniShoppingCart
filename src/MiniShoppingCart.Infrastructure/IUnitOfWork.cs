﻿namespace MiniShoppingCart.Infrastructure
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public interface IUnitOfWork
    {
        int SaveChanges();
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ShoppingCart> ShoppingCarts { get; set; }
        void BeginTransaction();
        void CommitTransaction();
    }
}