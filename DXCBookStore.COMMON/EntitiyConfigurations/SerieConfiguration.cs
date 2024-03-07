using DXCBookStore.COMMON.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DXCBookStore.COMMON.EntityConfigurations
{
    public class SerieConfiguration : BaseEntityTypeConfiguration<Serie>
    {
        public override void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.ToTable("series");
            
            base.Configure(builder);

            builder.Property(e => e.SerieName)
                   .HasMaxLength(100)
                   .HasColumnName("serie_name");

            builder.Property(e => e.StartYear)
                   .HasColumnName("start_year");

            builder.Property(e => e.EndYear)
                   .HasColumnName("end_year");

            builder.Property(e => e.IsDeleted)
                   .HasColumnName("is_deleted")
                   .IsRequired(false);

            builder.Property(e => e.PublisherId)
                   .HasColumnName("publisher_id");

            builder.HasOne(e => e.Publisher)
                   .WithMany(b => b.Series)
                   .HasConstraintName("FK_PUBLISHER_SERIES")
                   .HasForeignKey(e => e.PublisherId);
        }
    }
}
