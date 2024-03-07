using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreMVC.ModelConfigurations
{
    public class ImageConfiguration:BaseEntityTypeConfiguration<Image>
    {
        public override void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("images");

            base.Configure(builder);

            builder.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image_named")
                    .IsRequired(false); ;

            builder.Property(e => e.IdBook)
                   .HasColumnName("id_book");

            builder.HasOne(d => d.Book)
                   .WithMany(e => e.Images)
                   .HasForeignKey(d => d.IdBook)
                   .HasConstraintName("FK_IMAGES_BOOK")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
