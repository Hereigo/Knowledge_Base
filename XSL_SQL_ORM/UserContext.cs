using System.Data.Entity;

namespace XSL_SQL_ORM
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DBConn") { }

        public DbSet<User> Users { get; set; }
    }
}
