using Domain.DataAccess.Entites;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DataAccess
{
    public class DomainDbContext : DbContext
    {
        public DomainDbContext(DbContextOptions<DomainDbContext> options)
            : base(options)                      // указание опций с наледованием от базового конструктора
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Один ко многим: категория -> продукты
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // Множество ко множеству: заказ -> продукты
            modelBuilder.Entity<OrderItem>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(i => i.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(i => i.ProductId);
        }
    }
    }
