using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductType>()
               .Property<int>("Id")
               .ValueGeneratedNever(); // Disable identity
            modelBuilder.Entity<ProductBrand>()
               .Property<int>("Id")
               .ValueGeneratedNever(); // Disable identity
        }



    }
}
