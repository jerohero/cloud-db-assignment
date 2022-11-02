using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL {
    public sealed class BmhContext : DbContext
    {
        public DbSet<House> Houses { get; }
        public DbSet<Customer> Customers { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(u => u.Id).ValueGeneratedOnAdd();
        }

        public BmhContext(DbContextOptions<BmhContext> options, DbSet<House> houses, DbSet<Customer> customers) : base(options) {
            Houses = houses;
            Customers = customers;
            Database.EnsureCreated();
        }
    }   
}
