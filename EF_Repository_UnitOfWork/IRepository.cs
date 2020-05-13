using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EF_Repository_UnitOfWork
{
    public interface IRepository<T> where T : class
    {
        T Get(object id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void AddRange(IEnumerable<T> entities);

        // Returns result as Querayable for ability to apply more logic on top of it  
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
