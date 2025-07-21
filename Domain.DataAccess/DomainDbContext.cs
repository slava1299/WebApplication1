using Domain.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace Domain.DataAccess
{
    public class DomainDbContext: DbContext
    {
        public DomainDbContext(DbContextOptions<DomainDbContext> options) 
            :base (options)                      // указание опций с наледованием от базового конструктора
        {

        } 
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductEntity> Categories { get; set; }
    }
}
