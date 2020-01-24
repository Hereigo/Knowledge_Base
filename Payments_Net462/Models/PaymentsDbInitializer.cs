using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace Payments_Net462.Models
{
    public class PaymentsDbInitializer : CreateDatabaseIfNotExists<PaymentsContext>
    {
        protected override void Seed(PaymentsContext context)
        {
            // FIRST INITIALIZATION SEEDING :
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

                // ADD ONE PAYMENT DATA TO INIT DB TABLE:

                context.Payments.Add(new Payment { CatogoryId = 1, Amount = 100, Description = ("	Prev.Summary.	").Trim(), PayDate = DateTime.ParseExact(("	3/29/2018	").Trim(), "M/d/yyyy", CultureInfo.InvariantCulture) });

                base.Seed(context);
            }

            if (!context.Categories.Contains(new Category { Name = "BMO", IsActive = true, ID = 20 }))
            {
                context.Categories.Add(new Category { Name = "BMO", IsActive = true, ID = 20 });

                base.Seed(context);
            }

            if (!context.Categories.Contains(new Category { Name = "OLD", IsActive = true, ID = 21 }))
            {
                context.Categories.Add(new Category { Name = "OLD", IsActive = true, ID = 21 });

                base.Seed(context);
            }
        }
    }
}