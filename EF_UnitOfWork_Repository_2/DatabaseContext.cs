using System.Data.Entity;

namespace EF_UnitOfWork_Repository_2
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<BizOneEntity> BizOneContext { get; }

        public DbSet<BizTwoEntity> BizTwoContext { get; }
    }
}
