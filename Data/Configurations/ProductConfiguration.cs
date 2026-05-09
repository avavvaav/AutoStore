using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoStore.Models;

namespace AutoStore.Data.Configurations;

// Fluent API для таблицы "Автозапчасти"
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Description).HasMaxLength(2000);

        // Цена в формате decimal(18,2)
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.ImageUrl).HasMaxLength(500);

        // Связь 1:1 с характеристиками; при удалении запчасти удаляются и они
        builder.HasOne(p => p.Details)
               .WithOne(d => d.Product)
               .HasForeignKey<ProductDetails>(d => d.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
