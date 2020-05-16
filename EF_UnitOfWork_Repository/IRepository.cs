using System;
using System.Linq;
using System.Linq.Expressions;

namespace EF_UnitOfWork_Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition);

        bool Add(T entity);

        T GetSingle(Expression<Func<T, bool>> whereCondition);
    }
}
