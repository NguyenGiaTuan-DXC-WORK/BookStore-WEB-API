using BookStoreMVC.ModelConfigurations;
using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMVC.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply seperate configuration
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new SerieConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Image> Images { get; set; }
    }
}
