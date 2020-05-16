using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EF_UnitOfWork_Repository_2
{
    internal class RepositoryGeneral<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _dbCtx;

        public RepositoryGeneral(DatabaseContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        // Define the type of context Entity :
        private IDbSet<T> DbSet => _dbCtx.Set<T>();

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetEntity(Expression<Func<T, bool>> whereCondition)
        {
            return DbSet.FirstOrDefault(whereCondition);
        }
    }
}
