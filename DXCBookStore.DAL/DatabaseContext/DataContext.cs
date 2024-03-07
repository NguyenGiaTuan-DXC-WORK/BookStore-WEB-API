using DXCBookStore.COMMON.EntityConfigurations;
using DXCBookStore.COMMON.Entities;
using Microsoft.EntityFrameworkCore;
using DXCBookStore.COMMON.EntitiyConfigurations;
using System.Reflection.Emit;
using DXCBookStore.COMMON.Models.ResponseModels;

namespace DXCBookStore.DAL.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Apply seperate configuration
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new SerieConfiguration());
            builder.ApplyConfiguration(new PublisherConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new InvoiceConfiguration());
            builder.ApplyConfiguration(new InvoiceDetailConfiguration());

            // Config for Report   

            builder.Entity<ReportReponseModel>(entity =>
            {
                entity.HasNoKey();
            });

            base.OnModelCreating(builder);

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<ReportReponseModel> ReportResponseModels { get; set; }
    }
}
