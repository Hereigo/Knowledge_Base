using System;
using Autofac;

namespace DI_Autofac_Net462
{
    internal static class Program
    {
        private static void Main()
        {
            IContainer container = AutofacConfig.Configure();

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                IBussinessLogic logic = scope.Resolve<IBussinessLogic>();

                logic.ProcessData();
            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
