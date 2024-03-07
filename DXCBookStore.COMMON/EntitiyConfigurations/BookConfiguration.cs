using DXCBookStore.COMMON.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DXCBookStore.COMMON.EntityConfigurations
{
    public class BookConfiguration : BaseEntityTypeConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");
            
            base.Configure(builder);

            builder.Property(e => e.Title)
                   .HasMaxLength(250)
                   .HasColumnName("title");

            builder.Property(e => e.Author)
                   .HasMaxLength(100)
                   .HasColumnName("author");

            builder.Property(e => e.Price)
                   .HasColumnName("price");

            builder.Property(e => e.Quantity)
                  .HasColumnName("quantity");

            builder.Property(e => e.TotalPage)
                   .HasColumnName("total_page");

            builder.Property(e => e.PublishedDate)
                   .HasColumnType("date")
                   .HasColumnName("published_date");

            builder.Property(e => e.Description)
                   .HasColumnName("description")
                   .HasColumnType("nvarchar(max)");

            builder.Property(e => e.DeletedDate)
                   .HasColumnType("date")
                   .HasColumnName("deleted_date")
                   .IsRequired(false);
            // Config key for serie, category, publisher
            builder.Property(e => e.CategoryId)
                   .HasColumnName("category_id");

            builder.HasOne(e => e.Category)
                   .WithMany(b => b.Books)
                   .HasConstraintName("FK_CATEGORY_BOOKS")
                   .HasForeignKey(e => e.CategoryId);

            builder.Property(e => e.SerieId)
                   .HasColumnName("serie_id")
                   .IsRequired(false);

            builder.HasOne(e => e.Serie)
                   .WithMany(b => b.Books)
                   .HasConstraintName("FK_SERIE_BOOKS")
                   .HasForeignKey(e => e.SerieId);

            builder.Property(e => e.PublisherId)
                   .HasColumnName("publisher_id");

            builder.HasOne(e => e.Publisher)
                   .WithMany(b => b.Books)
                   .HasConstraintName("FK_PUBLISHER_BOOKS")
                   .HasForeignKey(e => e.PublisherId);
        }
    }
}
