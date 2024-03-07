using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.EntitiyConfigurations
{
    public class CustomerConfiguration:BaseEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            base.Configure(builder);

            // Turn off value generated on add for ID field

            builder.Property(x => x.Id)
              .ValueGeneratedNever();

            builder.Property(e => e.FullName)
                  .HasMaxLength(250)
                  .HasColumnName("full_name");

            builder.Property(e => e.ShippingAddress)
                  .HasMaxLength(250)
                  .HasColumnName("shipping_address");

            builder.Property(e => e.DateOfBirth)
                  .HasColumnType("date")
                  .HasColumnName("date_of_birth")
                  .IsRequired(false);

            builder.Property(e => e.Phone)
                  .HasMaxLength(20)
                  .HasColumnName("phone");

            builder.Property(e => e.Gender)
                   .HasColumnName("gender")
				   .IsRequired(false);
        }
    }
}
