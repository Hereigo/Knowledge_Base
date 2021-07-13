using Microsoft.EntityFrameworkCore;

namespace RawSqlCommandsGenerator
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
