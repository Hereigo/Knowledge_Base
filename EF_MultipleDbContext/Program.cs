using System;
using System.Linq;
using EF_MultipleDbContext.Database;
using EF_MultipleDbContext.Models;

namespace EF_MultipleDbContext
{
    internal static class Program
    {
        private static void Main()
        {
            DatabaseInitialize.Do();

            var dataManager = new DataManager();

            IPerson person = Teacher.GenerateOne();

            dataManager.InsertIntoDb(person);

            // Implement for Derived object :

            person = Student.GenerateOne();

            dataManager.InsertIntoDb(person);

            using (var context = new MyStudentContext())
            {
                Console.WriteLine("\n Retrieve all Students from the database:\n ");

                foreach (var stud in context.Students.OrderBy(s => s.ID))
                {
                    Console.WriteLine(
                        $"ID: {stud.ID}, Name: {stud.FirstMidName} {stud.LastName}");
                }
            }

            using (var context = new MyTeacherContext())
            {
                Console.WriteLine("\n Retrieve all teachers from the database:\n ");

                foreach (var teacher in context.Teachers.OrderBy(s => s.ID))
                {
                    Console.WriteLine(
                        $"ID: {teacher.ID}, Name: {teacher.FirstMidName} {teacher.LastName}");
                }
            }

            //Console.WriteLine("\n Press any key to exit...");
            //Console.ReadKey();
        }
    }
}
