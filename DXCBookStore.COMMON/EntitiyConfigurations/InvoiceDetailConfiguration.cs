using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DXCBookStore.COMMON.EntitiyConfigurations
{
    public class InvoiceDetailConfiguration:BaseEntityTypeConfiguration<InvoiceDetail>
    {
        public override void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("invoice_details");
            base.Configure(builder);

            builder.Property(e => e.Note)
                   .HasColumnName("note")
                   .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Price)
                   .HasColumnType("decimal(18, 2)")
                   .HasColumnName("price");

            builder.Property(e => e.BookId)
                   .HasColumnName("book_id");

            builder.Property(e => e.Quantity)
                  .HasColumnName("quantity");

            builder.Property(e => e.InvoiceId)
                   .HasColumnName("invoice_id");

            builder.HasOne(e => e.Book)
                   .WithMany(i => i.InvoiceDetails)
                   .HasConstraintName("FK_BOOK_INVOICE_DETAILS")
                   .HasForeignKey(e => e.BookId);

            builder.HasOne(e => e.Invoice)
                   .WithMany(i => i.InvoiceDetails)
                   .HasConstraintName("FK_INVOICE_INVOICE_DETAILS")
                   .HasForeignKey(e => e.InvoiceId);
        }
    }
}