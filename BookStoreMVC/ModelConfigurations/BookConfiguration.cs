using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreMVC.ModelConfigurations
{
    public class BookConfiguration : BaseEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");
            
            base.Configure(builder);

            builder.Property(e => e.Title)
                   .HasMaxLength(250)
                   .HasColumnName("title");

            builder.Property(e => e.Price)
                   .HasColumnName("price");

            builder.Property(e => e.PublishedDate)
                   .HasColumnType("date")
                   .HasColumnName("published_date");

            builder.Property(e => e.DeletedDate)
                   .HasColumnType("date")
                   .HasColumnName("deleted_date")
                   .IsRequired(false);

            builder.Property(e => e.IdSerie)
                   .HasColumnName("id_serie")
                   .IsRequired(false);

            builder.Property(e => e.IdCategory)
                   .HasColumnName("id_category");

        }
    }
}
