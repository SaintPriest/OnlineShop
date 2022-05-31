using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet <Review> Reviews { get; set; }
        public DbSet <Payment> Payments  { get; set; }
    }
}
