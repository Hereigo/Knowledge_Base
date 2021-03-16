using System.Data.Entity;
using System.Linq;

namespace EF_Repository_UnitOfWork
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        private IDbSet<T> DbSet => _dbContext.Set<T>();

        public IQueryable<T> Entities => DbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
    }
}
