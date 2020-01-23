namespace Payments_MVC_472.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Payments_MVC_472.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PaymentsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PaymentsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { Name = "CSH", IsActive = true });//1
                context.Categories.Add(new Category { Name = "ALF", IsActive = true });//2
                context.Categories.Add(new Category { Name = "PRV", IsActive = true });//3
                context.Categories.Add(new Category { Name = "CEX", IsActive = true });//4
                context.Categories.Add(new Category { Name = "WOK", IsActive = true });//5
                context.Categories.Add(new Category { Name = "STU", IsActive = true });//6
                context.Categories.Add(new Category { Name = "HOM", IsActive = true });//7
                context.Categories.Add(new Category { Name = "KID", IsActive = true });//8
                context.Categories.Add(new Category { Name = "KIU", IsActive = true });//9
                context.Categories.Add(new Category { Name = "QVN", IsActive = true });//10
                context.Categories.Add(new Category { Name = "FOO", IsActive = true });//11
                context.Categories.Add(new Category { Name = "COF", IsActive = true });//12
                context.Categories.Add(new Category { Name = "HLS", IsActive = true });//13
                context.Categories.Add(new Category { Name = "CLO", IsActive = true });//14
                context.Categories.Add(new Category { Name = "VIH", IsActive = true });//15
                context.Categories.Add(new Category { Name = "ENJ", IsActive = true });//16
                context.Categories.Add(new Category { Name = "PEB", IsActive = true });//17
                context.Categories.Add(new Category { Name = "VLG", IsActive = true });//18
                context.Categories.Add(new Category { Name = "KSH", IsActive = true });//19
                context.Categories.Add(new Category { Name = "BMO", IsActive = true, ID = 43 });//20
                context.Categories.Add(new Category { Name = "OLD", IsActive = true, ID = 44 });//21
                context.Categories.Add(new Category { Name = "RLS", IsActive = true, ID = 45 });//21
                context.Categories.Add(new Category { Name = "REL", IsActive = true, ID = 39 });//21

                // ADD ONE PAYMENT DATA TO INIT DB TABLE:

                // context.Payments.Add(new Payment { CatogoryId = 1, Amount = 100, Description = ("	Prev.Summary.	").Trim(), PayDate = DateTime.ParseExact(("	3/29/2018	").Trim(), "M/d/yyyy", CultureInfo.InvariantCulture) });

                base.Seed(context);
            }
        }
    }
}
