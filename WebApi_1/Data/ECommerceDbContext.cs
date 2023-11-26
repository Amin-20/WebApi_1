using Microsoft.EntityFrameworkCore;
using WebApi_1.Entities;

namespace WebApi_1.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext>options)
            :base(options)
        {
                
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
