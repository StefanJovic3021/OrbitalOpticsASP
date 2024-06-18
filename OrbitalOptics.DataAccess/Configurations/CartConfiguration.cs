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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            // User id configuration
            builder.HasIndex(x => x.UserId)
                   .IsUnique();

            // Foreign key configuration
            builder.HasOne(x => x.User)
                   .WithOne(x => x.Cart)
                   .HasForeignKey<Cart>(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.CartPrices)
                   .WithOne(x => x.Cart)
                   .HasForeignKey(x => x.CartId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
