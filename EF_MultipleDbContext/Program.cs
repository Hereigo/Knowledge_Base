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

            IPerson personStudent = dataManager.GetStudent();
            dataManager.ClonePerson(personStudent);

            IPerson personTeacher = dataManager.GetTeacher();
            dataManager.ClonePerson(personTeacher);

            using (var context = new MyStudentContext())
            {
                Console.WriteLine("\n Retrieve all Students from the database:\n ");

                var students = (from s in context.Students
                                orderby s.FirstMidName
                                select s).ToList();

                foreach (var stdnt in students)
                {
                    string name = stdnt.FirstMidName + " " + stdnt.LastName;
                    Console.WriteLine("ID: {0}, Name: {1}", stdnt.ID, name);
                }
            }

            using (var context = new MyTeacherContext())
            {
                Console.WriteLine("\n Retrieve all teachers from the database:\n ");

                var teachers = (from t in context.Teachers
                                orderby t.FirstMidName
                                select t).ToList();

                foreach (var teacher in teachers)
                {
                    string name = teacher.FirstMidName + " " + teacher.LastName;
                    Console.WriteLine("ID: {0}, Name: {1}", teacher.ID, name);
                }
            }

            Console.WriteLine("\n Press any key to exit...");
            Console.ReadKey();
        }
    }
}
