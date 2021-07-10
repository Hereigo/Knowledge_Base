using System.Data.Entity;

namespace EF_UnitOfWork
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EntityA> EntityA { get; set; }
        public DbSet<EntityB> EntityB { get; set; }
    }
}
