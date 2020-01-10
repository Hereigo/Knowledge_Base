using System.Data.Entity;

namespace Payments_MVC_472.Models
{
    public class PaymentsDbContext : DbContext
    {
        public PaymentsDbContext() { }

        DbSet<Category> Categories { get; set; }

        DbSet<Payment> Payments { get; set; }
    }
}