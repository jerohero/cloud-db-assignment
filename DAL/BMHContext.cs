using Microsoft.EntityFrameworkCore;
using Repository;

namespace BMH.DAL;
public class BMHContext : DbContext
{
    public DbSet<House> Houses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<House>().Property(u => u.Id).ValueGeneratedOnAdd();
    }

        public BMHContext(DbContextOptions<BMHContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
