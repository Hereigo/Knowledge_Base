using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Dapper_use
{
    public enum EmployeeNames
    {
        Alex,
        Alexandra,
        Felix,
        Max,
        Maria,
        Jose,
        aaa
    }

    public class Employee
    {
        public int Emp_Id { get; set; }
        public int Emp_Age { get; set; }
        public EmployeeNames Emp_Name { get; set; }
        public string Emp_City { get; set; }
    }

    static class Program
    {
        private static async Task Main()
        {
            using IDbConnection connection =
                new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AngJSAsp4_Employees;Integrated Security=True;");

            var people =
                await connection.QueryAsync<Employee>("select * from Employee");

            foreach (var person in people)
            {
                Console.WriteLine($"Hello from {person.Emp_Name}");
            }

            var name = EmployeeNames.Felix;
            var city = "Wakanda";
            var age = 101;

            var count =
                await connection
                    .ExecuteAsync(
                        "insert Employee(Emp_Name, Emp_City, Emp_Age) values (@name, @city, @age)",
                        new { name, city, age });

            Console.WriteLine($"Inserted {count} rows.");

            var employees =
                await connection.QueryAsync<Employee>("select * from Employee");

            foreach (var person in employees)
            {
                Console.WriteLine($"Hello from {person.Emp_Name}");
            }

            Console.ReadKey();
        }
    }
}
