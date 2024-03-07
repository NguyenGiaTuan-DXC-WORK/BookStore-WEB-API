using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreMVC.ModelConfigurations
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

            builder.Property(e => e.CategoryParentId)
                   .HasColumnName("category_parent_id")
                   .IsRequired(false);

            builder.HasOne(e => e.CategoryParent)
                   .WithMany(d => d.ChildCategories)
                   .HasForeignKey(e => e.CategoryParentId)
                   .HasConstraintName("FK_CATEGORY_PARENT")
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
