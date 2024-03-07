using DXCBookStore.COMMON.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DXCBookStore.COMMON.EntityConfigurations
{
    public class CategoryConfiguration : BaseEntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");

            base.Configure(builder);

            builder.Property(e => e.CategoryName)
                   .HasMaxLength(100)
                   .HasColumnName("category_name");

            builder.Property(e => e.CategoryIcon)
                   .HasMaxLength(250)
                   .HasColumnName("category_icon");

            builder.Property(e => e.IsDeleted)
                   .HasColumnName("is_deleted")
                   .IsRequired(false);


            builder.Property(e => e.CategoryParentId)
                    .HasColumnName("category_parent_id")
                    .IsRequired(false);

            builder.HasOne(e => e.CategoryParent)
                   .WithMany(e => e.InverseParent)
                   .HasForeignKey(e => e.CategoryParentId)
                   .HasConstraintName("FK_CATEGORY_PARENT_ID"); 
        }
    }
}
