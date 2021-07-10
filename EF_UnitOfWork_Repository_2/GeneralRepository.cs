using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EF_UnitOfWork_Repository
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<EntityA> a { get; }
        public DbSet<EntityB> b { get; }
    }

    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetEntity(Expression<Func<T, bool>> whereCondition);
        IQueryable<T> GetAll();
    }

    internal class GeneralRepository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _dbCtx;

        public GeneralRepository(DatabaseContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        // Switch Context :
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
