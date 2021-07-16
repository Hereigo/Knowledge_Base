using Microsoft.EntityFrameworkCore;

namespace EF_Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}