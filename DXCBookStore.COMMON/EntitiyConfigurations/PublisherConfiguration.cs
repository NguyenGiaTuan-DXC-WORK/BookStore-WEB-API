using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DXCBookStore.COMMON.EntitiyConfigurations
{
    public class PublisherConfiguration : BaseEntityTypeConfiguration<Publisher>
    {
        public override void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("publishers");

            base.Configure(builder);

            // Turn off value generated on add for ID field

            builder.Property(x => x.Id)
              .ValueGeneratedNever();

            builder.Property(e => e.BrandName)
                  .HasMaxLength(250)
                  .HasColumnName("brand_name");

            builder.Property(e => e.HeadOfficeAddress)
                  .HasMaxLength(250)
                  .HasColumnName("head_office_address");

            builder.Property(e => e.ContactMail)
                  .HasMaxLength(100)
                  .HasColumnName("contact_mail");

            builder.Property(e => e.HotLine)
                  .HasMaxLength(250)
                  .HasColumnName("hot_line");

            builder.Property(e => e.Description)
                   .HasColumnName("description")
                   .HasColumnType("nvarchar(max)");

            builder.Property(e => e.IsActive)
                  .HasColumnName("is_active")
                  .IsRequired(true);
        }
    }
}

