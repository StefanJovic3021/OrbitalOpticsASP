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
    public class UseCaseLogConfiguration : IEntityTypeConfiguration<UseCaseLog>
    {
        public void Configure(EntityTypeBuilder<UseCaseLog> builder)
        {
            // Username configuration
            builder.Property(x => x.Username)
                   .IsRequired()
                   .HasMaxLength(20);

            // Use case name configuration
            builder.Property(x => x.UseCaseName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Index configuration
            builder.HasIndex(x => new { x.Username, x.UseCaseName, x.ExecutedAt })
                   .IncludeProperties(x => x.UseCaseData);
        }
    }
}
