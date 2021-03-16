using System.Data.Entity;

namespace EF_UnitOfWork
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EntityOne> EntityOne { get; set; }

        public DbSet<EntityTwo> EntityTwo { get; set; }
    }
}
