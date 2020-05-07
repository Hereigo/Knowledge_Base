using System.Data.Entity;
using EF_MultipleDbContext.Models;

namespace EF_MultipleDbContext.Database
{
    public class MyStudentContext : DbContext
    {
        public MyStudentContext() : base("NotDefaultConnection") { }

        public virtual DbSet<Student> Students { get; set; }
    }
}
