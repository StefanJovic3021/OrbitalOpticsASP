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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Username configuration
            builder.Property(x => x.Username)
                   .HasMaxLength(40)
                   .IsRequired();
            builder.HasIndex(x => x.Username)
                   .IsUnique();

            // Email configuration
            builder.Property(x => x.Email)
                   .HasMaxLength(60)
                   .IsRequired();
            builder.HasIndex(x => x.Email)
                   .IsUnique();

            // Password configuration
            builder.Property(x => x.Password)
                   .HasMaxLength(120)
                   .IsRequired();

            // Search index
            builder.HasIndex(x => new { x.Username, x.Email, x.Password });

            // Foreign key configuration
            builder.HasOne(x => x.Image)
                   .WithOne(x => x.User)
                   .HasForeignKey<User>(x => x.ImageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
