using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.OwnsOne(x => x.Barcode);
            builder.OwnsOne(x => x.Category);
            builder.OwnsOne(x => x.Weight);
            builder.HasMany(i => i.OrderDetails);
            builder.Navigation(e => e.Barcode).IsRequired();
            builder.Navigation(e => e.Category).IsRequired();
        }

    }
}
