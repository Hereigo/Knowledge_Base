using System.Data.Entity;

namespace EF_Repository_UnitOfWork
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        //public AppDbContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{
        //}
    }
}