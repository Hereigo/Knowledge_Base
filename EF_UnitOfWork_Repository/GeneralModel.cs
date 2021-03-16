using System.Data.Entity;

namespace EF_UnitOfWork_Repository
{
    public class GeneralModel : DbContext
    {
        // public DbSet<T> Set<T>() {...
        public virtual DbSet<BalanceC> Balance { get; set; }
        public virtual DbSet<BalanceCAP> BalanceAP { get; set; }
    }
}