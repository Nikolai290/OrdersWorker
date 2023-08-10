using Microsoft.EntityFrameworkCore;
using OrdersWorker.Core.DbEntities;

namespace OrdersWorker.Domain.Implements;

public class MsSqlContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(d => d.Id);
    }

}