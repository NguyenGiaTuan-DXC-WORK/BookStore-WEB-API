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
    public class InvoiceConfiguration:BaseEntityTypeConfiguration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoices");
            base.Configure(builder);

            builder.Property(e => e.ShippingAddress)
                   .HasMaxLength(250)
                   .HasColumnName("shipping_address");

            builder.Property(e => e.Phone)
                   .HasMaxLength(20)
                   .HasColumnName("phone");

            builder.Property(x => x.PaidDate)
                   .HasColumnType("date")
                   .HasColumnName("paid_date");

            builder.Property(e => e.TotalPrice)
                   .HasColumnType("decimal(18, 2)")
                   .HasColumnName("total_price");

            builder.Property(e => e.CustomerId)
                   .HasColumnName("customer_id");

            builder.HasOne(e => e.Customer)
                   .WithMany(i => i.Invoices)
                   .HasConstraintName("FK_CUSTOMER_INVOICES")
                   .HasForeignKey(e => e.CustomerId);
        }
    }
}
