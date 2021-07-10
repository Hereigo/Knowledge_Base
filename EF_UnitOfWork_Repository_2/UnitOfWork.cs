using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EF_UnitOfWork_Repository
{
    public interface IUnitOfWork
    {
        IRepository<EntityA> RepositoryA { get; }
        IRepository<EntityB> RepositoryB { get; }
        void Commit();
        // Discards all changes that has not been commited.
        void RejectChanges();
        void Dispose();
    }

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbCtx;

        public UnitOfWork(DatabaseContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public IRepository<EntityA> RepositoryA => new GeneralRepository<EntityA>(_dbCtx);
        public IRepository<EntityB> RepositoryB => new GeneralRepository<EntityB>(_dbCtx);

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
