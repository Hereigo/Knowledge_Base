using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MyXpens
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                                .ConfigureWebHostDefaults(webBuilder =>
                                {
                                    webBuilder.UseStartup<Startup>();
                                    // webBuilder.UseUrls("http://192.168.0.105:5003");
                                    // To call from outside don't forget to switch firewall :
                                    // sudo ufw [allow\deny] in 5003 
                                });
    }
}