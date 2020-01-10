using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Service_Lifetimes
{
    internal static class Program
    {
        private static void Main()
        {
            ServiceProvider serviceProvider = BuildServiceProvider();

            Console.WriteLine("========== Request 1 ============");
            serviceProvider.GetService<ITransientSvc>().Info();
            serviceProvider.GetService<IScopedSvc>().Info();
            serviceProvider.GetService<ISingletonSvc>().Info();

            Console.WriteLine("========== Request 2 ============");
            serviceProvider.GetService<ITransientSvc>().Info();
            serviceProvider.GetService<IScopedSvc>().Info();
            serviceProvider.GetService<ISingletonSvc>().Info();

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                Console.WriteLine("========== Request 3 Scope 1 ============");
                scope.ServiceProvider.GetService<IScopedSvc>().Info();
                scope.ServiceProvider.GetService<ITransientSvc>().Info();
                scope.ServiceProvider.GetService<ISingletonSvc>().Info();

                Console.WriteLine("========== Request 4 Scope 1 ============");
                scope.ServiceProvider.GetService<IScopedSvc>().Info();
                scope.ServiceProvider.GetService<ISingletonSvc>().Info();
            }

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                Console.WriteLine("========== Request 5 Scope 2 ============");
                scope.ServiceProvider.GetService<IScopedSvc>().Info();
                scope.ServiceProvider.GetService<ISingletonSvc>().Info();
            }

            Console.WriteLine("========== Request 6 ============");
            serviceProvider.GetService<IScopedSvc>().Info();

            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }

        // BUILD SERVICE PROVIDER :

        private static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<ITransientSvc, OperationTransient>()
                .AddScoped<IScopedSvc, OperationScoped>()
                .AddSingleton<ISingletonSvc, OperationSingleton>()
                .BuildServiceProvider();
        }
    }
}
// ========== Request 1 ============
// Operation - Transient Service Created.
// Operation - Transient: 13ba847c-eba5-4d52-b01c-a81ace3ab765
// Operation - Scoped Service Created.
// Operation - Scoped: 11111111-1111-1111-1111-111111111111
// Operation - Singleton Service Created.
// Operation - Singleton: 22222222-2222-2222-2222-222222222222
//
// ========== Request 2 ============
// Operation - Transient Service Created.
// Operation - Transient: 14fd5818-a9b5-4e67-be7b-a4e6360165fb
// Operation - Scoped: 11111111-1111-1111-1111-111111111111
// Operation - Singleton: 22222222-2222-2222-2222-222222222222
//
// ========== Request 3 Scope 1 ============
// Operation - Scoped Service Created.
// Operation - Scoped: 33333333-3333-3333-3333-333333333333
// Operation - Transient Service Created.
// Operation - Transient: 67b751d0-d049-4917-b6dc-27e1fe727503
// Operation - Singleton: 22222222-2222-2222-2222-222222222222
//
// ========== Request 4 Scope 1 ============
// Operation - Scoped: 33333333-3333-3333-3333-333333333333
// Operation - Singleton: 22222222-2222-2222-2222-222222222222
//
// ========== Request 5 Scope 2 ============
// Operation - Scoped Service Created.
// Operation - Scoped: f935d5fe-b6db-4bda-9ec1-924307009b71
// Operation - Singleton: 22222222-2222-2222-2222-222222222222
//
// ========== Request 6 ============
// Operation - Scoped: 11111111-1111-1111-1111-111111111111