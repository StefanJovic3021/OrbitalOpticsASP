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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Name configuration
            builder.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(x => x.Name)
                   .IsUnique();

            // Description configuration
            builder.Property(x => x.Description)
                   .HasMaxLength(256)
                   .IsRequired();

            // Foreign key configuration
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Company)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.Companyid)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Image)
                   .WithOne(x => x.Product)
                   .HasForeignKey<Product>(x => x.ImageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
