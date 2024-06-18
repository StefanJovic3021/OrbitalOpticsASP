using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrbitalOptics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOptics.DataAccess.Configurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            // Product price configuration
            builder.Property(x => x.ProductPrice)
                   .IsRequired();
            builder.HasIndex(x => x.ProductPrice);

            // Foreign key configuration
            builder.HasOne(x => x.Product)
                   .WithOne(x => x.Price)
                   .HasForeignKey<Price>(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.CartPrices)
                   .WithOne(x => x.Price)
                   .HasForeignKey(x => x.PriceId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.OrderPrices)
                   .WithOne(x => x.Price)
                   .HasForeignKey(x => x.PriceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
