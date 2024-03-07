using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DXCBookStore.COMMON.EntitiyConfigurations
{
    public class AccountConfiguration:BaseEntityTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");
            base.Configure(builder);

            builder.Property(e => e.UserName)
                   .HasMaxLength(250)
                   .HasColumnName("user_name");

            builder.Property(e => e.PassWord)
                   .HasMaxLength(500)
                   .HasColumnName("pass_word");

            builder.Property(e => e.Role)
                   .HasMaxLength(100)
                   .HasColumnName("role");

            builder.Property(x => x.LastLoggedIn)
                  .HasColumnType("date")
                  .HasColumnName("last_logged_in")
                  .IsRequired(false);

            // Config 1 publisher 1 account

            builder.HasOne(p => p.Publisher)
                  .WithOne(d => d.Account)
                  .HasConstraintName("FK_PUBLISHER_ACCOUNT")
                  .HasForeignKey<Publisher>(p => p.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            // Config 1 customer 1 account

            builder.HasOne(p => p.Customer)
                  .WithOne(d => d.Account)
                  .HasConstraintName("FK_CUSTOMER_ACCOUNT")
                  .HasForeignKey<Customer>(p => p.Id)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
