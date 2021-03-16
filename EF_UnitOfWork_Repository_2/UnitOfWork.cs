using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EF_UnitOfWork_Repository_2
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbCtx;

        public UnitOfWork(DatabaseContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public IRepository<BizOneEntity> RepositoryOne => new RepositoryGeneral<BizOneEntity>(_dbCtx);
        public IRepository<BizTwoEntity> RepositoryTwo => new RepositoryGeneral<BizTwoEntity>(_dbCtx);

        public void Commit()
        {
            _dbCtx.SaveChanges();
        }

        public void Dispose()
        {
            _dbCtx.Dispose();
        }

        public void RejectChanges()
        {
            foreach (DbEntityEntry entry in _dbCtx.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
