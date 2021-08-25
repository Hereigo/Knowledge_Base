using System.IO;
using System.Threading.Tasks;
using MediatR;
using MediatR_Runner_Ext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MediatR_Runner
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<JobRunner>().Run(args);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<AppSettings>(configuration.GetSection("ExecutingJobs"));
            services.AddMediatR(typeof(ProductOnBalanceClearHandler));
            services.AddMediatR(typeof(TestCommandHandler));
            services.AddScoped<JobRunner>();
        }
    }
}