using OrderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id); // Primary Key tanımlanmış durumda

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id); // Primary Key tanımlanmış durumda

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.Id); // Primary Key tanımlanmış durumda

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id); // Primary Key tanımlanmış durumda

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id); // Primary Key tanımlanmış durumda
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}