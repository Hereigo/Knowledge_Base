using CinoMCounter.Models;
using Microsoft.EntityFrameworkCore;

namespace CinoMCounter.Data
{
    public interface IPaymentsContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Payment> Payments { get; set; }
    }
}