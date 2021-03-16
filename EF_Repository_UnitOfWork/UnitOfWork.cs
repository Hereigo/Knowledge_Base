using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EF_Repository_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public IRepository<Author> AuthorRepository => new Repository<Author>(_dbContext);
        public IRepository<Book> BookRepository => new Repository<Book>(_dbContext);

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (DbEntityEntry entry in _dbContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
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