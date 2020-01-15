using System;
using System.Linq;

namespace SQL_EF_Autofac_Net462
{
    class Program
    {
        static void Main()
        {
            BaseRepository<Employee> employeeRepo = new BaseRepository<Employee>();

            IQueryable<Employee> rez = employeeRepo.GetByProcedureName(null, "spGetAllEmployees");


            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
