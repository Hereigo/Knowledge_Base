using System.Data.Entity;

namespace SQL_EF_Autofac_Net462
{
    public interface IEmployeeContext
    {
        DbSet<Employee> Employees { get; set; }
    }
}