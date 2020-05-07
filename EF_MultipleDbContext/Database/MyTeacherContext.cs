using System.Data.Entity;
using EF_MultipleDbContext.Models;

namespace EF_MultipleDbContext.Database
{
    public class MyTeacherContext : DbContext
    {
        public MyTeacherContext() : base("NotDefaultConnection") { }

        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
