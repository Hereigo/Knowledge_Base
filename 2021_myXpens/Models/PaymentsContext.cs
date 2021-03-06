﻿using Microsoft.EntityFrameworkCore;

namespace MyXpens.Models
{
    public class PaymentsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        public PaymentsContext(DbContextOptions<PaymentsContext> options)
            : base(options)
        {
            // Database.SetInitializer<PaymentsContext>(new CreateDatabaseIfNotExists<PaymentsContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaysSummary> PaysSummaries { get; set; }
    }
}