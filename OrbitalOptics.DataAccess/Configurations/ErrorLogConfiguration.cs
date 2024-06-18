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
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            // Message configuration
            builder.Property(x => x.Message)
                   .IsRequired();

            // Stack trace configuration
            builder.Property(x => x.StrackTrace)
                   .IsRequired();

            // Primary key configuration
            builder.HasKey(x => x.ErrorId);
        }
    }
}
