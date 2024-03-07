using DXCBookStore.COMMON.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DXCBookStore.COMMON.EntityConfigurations
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

            builder.Property(e => e.IdSerie)
                   .HasColumnName("id_serie");

            builder.HasOne(d => d.Book)
                   .WithMany(e => e.Images)
                   .HasForeignKey(d => d.IdBook)
                   .HasConstraintName("FK_IMAGES_BOOK")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Serie)
                  .WithOne(e => e.Image)
                  .HasForeignKey<Image>(d => d.IdSerie)
                  .HasConstraintName("FK_IMAGE_SERIE")
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
