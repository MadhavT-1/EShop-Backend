using EShop_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EShop_Backend.Config
{
    public class EshopDbContext : DbContext
    {

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Products> Products { get; set; }  
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Orders> Orders { get; set; }

        public EshopDbContext()
        {
                
        }
      
        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("host=localhost;username=postgres;password=root;database=EShopDb");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderItem>()
        //        .HasOne(p => p.Products);

        //}


    }
}
