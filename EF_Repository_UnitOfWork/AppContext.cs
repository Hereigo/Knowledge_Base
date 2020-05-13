using System.Data.Entity;

namespace EF_Repository_UnitOfWork
{
    class AppContext : DbContext
    {
        public DbSet Permissions { get; set; }
        public DbSet Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
