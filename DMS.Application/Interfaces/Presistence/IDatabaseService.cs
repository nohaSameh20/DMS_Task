using System;
using Domain.Customers;
using Domain.Items;
using Domain.Orders;
using Domain.Users;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        IRepository<Customer> Customers { get; }
        IRepository<Item> Items { get; }
        IRepository<UOM> UOMs { get; }
        IRepository<OrderDetails> OrderDetails { get; }
        IRepository<OrderHeader> OrderHeaders { get; }

        IRepository<User> Users { get; }


        IDatabaseService GetContext();
        void SaveChanges();
        bool ExecuteTransaction(Action transactionBody);
    }
}