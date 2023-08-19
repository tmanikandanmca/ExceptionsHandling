using ExceptionsHandling.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExceptionsHandling.Models.Configurations;

public class StockExchangeConfiguration : IEntityTypeConfiguration<StockExchangeEntity>
{
    public void Configure(EntityTypeBuilder<StockExchangeEntity> entity)
    {
        entity
             .ToTable("StocksExchange")
             .HasKey(e => e.ExchangeId)
             .HasName("Pk_ExchangeId");
        entity
            .Property(e => e.ExchangeId)
            .ValueGeneratedOnAdd()
            .HasColumnName("ExchangeId");
    }
}
