using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreMVC.ModelConfigurations
{
    public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate)
                   .HasColumnType("date")
                   .HasColumnName("created_date");

            builder.Property(x => x.UpdatedDate)
                   .HasColumnType("date")
                   .HasColumnName("updated_date")
                   .IsRequired(false);
        }
    }
}
