using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Application.Interfaces;
using Domain.Users;
using Domain.Customers;
using Domain.Items;
using Domain.Orders;

namespace Persistence.Core
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private string ConnectionString = "Data Source=DESKTOP-4UT1SMN\\SQLEXPRESS;Database=DMSDB;Trusted_Connection=true;MultipleActiveResultSets=True";
        private IServiceProvider provider;
        IDatabaseServiceOptions options; 

        public DatabaseService()
        {
        }

        public DatabaseService(IServiceProvider provider, IDatabaseServiceOptions options)
        {
            this.provider = provider;
            this.ConnectionString = options.ConnectionString;
            this.options = options; 
        }

        public IDatabaseService GetContext()
        {
            return new DatabaseService(provider, options); 
        }

        internal DbSet<User> Users { set; get; }
        internal DbSet<Customer> Customers { set; get; }
        internal DbSet<Item> Items { set; get; }
        internal DbSet<UOM> UOMs { set; get; }
        internal DbSet<OrderDetails> OrderDetails { set; get; }
        internal DbSet<OrderHeader> OrderHeaders { set; get; }


        IRepository<User> IDatabaseService.Users => provider.GetService<IRepository<User>>();
        IRepository<Customer> IDatabaseService.Customers => provider.GetService<IRepository<Customer>>();
        IRepository<Item> IDatabaseService.Items => provider.GetService<IRepository<Item>>();
        IRepository<UOM> IDatabaseService.UOMs => provider.GetService<IRepository<UOM>>();
        IRepository<OrderDetails> IDatabaseService.OrderDetails => provider.GetService<IRepository<OrderDetails>>();
        IRepository<OrderHeader> IDatabaseService.OrderHeaders => provider.GetService<IRepository<OrderHeader>>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        void IDatabaseService.SaveChanges()
        {
            var res= this.SaveChanges();
        }

        public virtual bool ExecuteTransaction(Action transactionBody)
        {
            using (var trans = this.Database.BeginTransaction())
            {
                try
                {
                    transactionBody.Invoke();
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }
    }
}