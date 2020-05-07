using System;
using System.Linq;
using EF_MultipleDbContext.Models;

namespace EF_MultipleDbContext.Database
{
    public static class DatabaseInitialize
    {
        public static void Do()
        {
            using (var context = new MyStudentContext())
            {
                if (!context.Students.Any())
                {
                    Console.WriteLine("\n Adding new students");

                    var student = new Student
                    {
                        FirstMidName = "Alain",
                        LastName = "Bomer",
                        StartDate = DateTime.Parse(DateTime.Today.AddYears(-1).ToString())
                    };

                    context.Students.Add(student);
                    context.SaveChanges();
                }
            }

            using (var context = new MyTeacherContext())
            {
                if (!context.Teachers.Any())
                {
                    Console.WriteLine("\n Adding new teachers");

                    var teacher = new Teacher
                    {
                        FirstMidName = "Mark",
                        LastName = "Upston",
                        StartDate = DateTime.Parse(DateTime.Today.ToString())
                    };

                    context.Teachers.Add(teacher);
                    context.SaveChanges();
                }
            }
        }
    }
}

