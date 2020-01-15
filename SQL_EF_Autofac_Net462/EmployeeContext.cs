using System.Data.Entity;

namespace SQL_EF_Autofac_Net462
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() { }

        public DbSet<Employee> Employees { get; set; }
    }
}
