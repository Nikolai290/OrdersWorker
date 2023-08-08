using Microsoft.EntityFrameworkCore;
using OrdersWorker.Core.DbEntities;

namespace OrdersWorker.Domain.Implements;

public class MsSqlContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<SystemType> SystemTypes { get; set; }

    public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
    {
        if (Database.EnsureCreated())
        {
            FirstInit().GetAwaiter();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(d => d.Id);
    }

    private async Task FirstInit()
    {
        var systemTypes = new List<SystemType>()
        {
            new(Guid.NewGuid(), "talabat"),
            new(Guid.NewGuid(), "zomato"),
            new(Guid.NewGuid(), "uber"),
        };
        SystemTypes.AddRange(systemTypes);
        await SaveChangesAsync();
    }
}