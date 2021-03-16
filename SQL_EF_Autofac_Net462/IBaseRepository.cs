using System.Linq;

namespace SQL_EF_Autofac_Net462
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetByProcedureName(T entity, string spName);
    }
}