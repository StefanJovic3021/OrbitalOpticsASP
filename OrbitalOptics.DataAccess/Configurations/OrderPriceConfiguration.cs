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
    public class OrderPriceConfiguration : IEntityTypeConfiguration<OrderPrice>
    {
        public void Configure(EntityTypeBuilder<OrderPrice> builder)
        {
            // Composite key configuration
            builder.HasKey(x => new { x.OrderId, x.PriceId });
        }
    }
}
