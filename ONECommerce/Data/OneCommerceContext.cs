using Microsoft.EntityFrameworkCore;
using ONECommerce.Models;

namespace ONECommerce.Data
{
    public class OneCommerceContext : DbContext
    {
        public OneCommerceContext(DbContextOptions<OneCommerceContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
