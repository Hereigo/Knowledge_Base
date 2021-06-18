using Microsoft.EntityFrameworkCore;

namespace Sql_CE31_EFCore_FromCoreTemplate
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        public DbSet<LastSync> LastSync { get; set; }
        public DbSet<BarCode> Barcodes { get; set; }
    }
}
