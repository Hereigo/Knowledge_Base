using System;
using System.Linq;
using System.Linq.Expressions;

namespace EF_UnitOfWork_Repository_2
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T GetEntity(Expression<Func<T, bool>> whereCondition);

        IQueryable<T> GetAll();
    }
}
