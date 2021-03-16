using System.Data.Entity;

namespace Payments_MVC_472.Models
{
    public class PaymentsDbContext : DbContext
    {
        public PaymentsDbContext() : base()
        {
            Database.SetInitializer<PaymentsDbContext>(new CreateDatabaseIfNotExists<PaymentsDbContext>());
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Payment> Payments { get; set; }
    }
}