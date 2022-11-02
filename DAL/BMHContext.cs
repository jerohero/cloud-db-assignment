using Microsoft.EntityFrameworkCore;
using BMH.Repository;
using BMH.Domain;

namespace BMH.DAL;
public class BMHContext : DbContext
{
    public DbSet<House> Houses { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<House>().Property(u => u.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Customer>().Property(u => u.Id).ValueGeneratedOnAdd();
    }

    public BMHContext(DbContextOptions<BMHContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
