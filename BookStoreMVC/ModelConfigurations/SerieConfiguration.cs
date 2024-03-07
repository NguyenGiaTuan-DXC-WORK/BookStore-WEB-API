using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreMVC.ModelConfigurations
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
        }
    }
}
