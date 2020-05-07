using System.Linq;
using EF_MultipleDbContext.Models;

namespace EF_MultipleDbContext.Database
{
    public class DataManager
    {
        internal IPerson GetStudent()
        {
            using (var ctx = new MyStudentContext())
            {
                return ctx.Students.FirstOrDefault();
            }
        }

        internal IPerson GetTeacher()
        {
            using (var ctx = new MyTeacherContext())
            {
                return ctx.Teachers.FirstOrDefault();
            }
        }

        internal void ClonePerson(IPerson person)
        {
            // if (person is Teacher) // will be Always TRUE !!!
            // if(((Teacher)person).IsTeacher)
            if (person is Student)
            {
                ((Student)person).FirstMidName = ((Student)person).FirstMidName.ToUpper();

                using (var ctx = new MyStudentContext())
                {
                    ctx.Students.Add((Student)person);
                    ctx.SaveChanges();
                }
            }
            else
            {
                ((Teacher)person).FirstMidName = ((Teacher)person).FirstMidName.ToUpper();

                using (var ctx = new MyTeacherContext())
                {
                    ctx.Teachers.Add((Teacher)person);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
