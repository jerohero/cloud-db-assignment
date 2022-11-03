using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DAL {
    public sealed class BmhContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            modelBuilder.Entity<House>().Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        }

        public BmhContext(DbContextOptions<BmhContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }   
}
