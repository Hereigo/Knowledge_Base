using System.Data.SqlClient;
using System.Linq;

namespace SQL_EF_Autofac_Net462
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public IQueryable<T> GetByProcedureName(T entity, string spName)
        {
            EmployeeContext _dbContext = new EmployeeContext();

            SqlParameter parameter1 = new SqlParameter("@SqlParameter1", 1234567);

            // IQueryable<T> 
            System.Data.Entity.Infrastructure.DbRawSqlQuery<T> result =
            _dbContext.Database.SqlQuery<T>(spName); // + " @SqlParameter1", parameter1); // as IQueryable<T>;

            return result as IQueryable<T>;
        }
    }
}
