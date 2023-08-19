using ExceptionsHandling.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ExceptionsHandling.Models;


public class MarketDbContext:DbContext
{
	public MarketDbContext(DbContextOptions<MarketDbContext> options):base(options)
	{
			
	}
    public DbSet<StockExchangeEntity> StockExchanges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

    }
}
