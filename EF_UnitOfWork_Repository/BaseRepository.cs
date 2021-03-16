using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EF_UnitOfWork_Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly GeneralModel _dbContext;

        protected DbSet<T> DbSet;

        public BaseRepository(GeneralModel dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            var result = Save();

            return result > 0;
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return DbSet.Where(whereCondition);
        }

        public T GetSingle(Expression<Func<T, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        private int Save()
        {
            var result = _dbContext.SaveChanges();
            return result;
        }
    }
}
