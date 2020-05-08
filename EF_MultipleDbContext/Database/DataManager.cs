using EF_MultipleDbContext.Models;

namespace EF_MultipleDbContext.Database
{
    public class DataManager
    {
        internal void InsertIntoDb(IPerson person)
        {
            // if (person is Teacher) // will be Always TRUE !!!
            // if(((Teacher)person).IsTeacher)
            if (person is Student)
            {
                using (var ctx = new MyStudentContext())
                {
                    ctx.Students.Add((Student)person);
                    ctx.SaveChanges();
                }
            }
            else
            {
                using (var ctx = new MyTeacherContext())
                {
                    ctx.Teachers.Add((Teacher)person);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
