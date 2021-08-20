using System;
using System.Threading.Tasks;
using Quartz;

namespace QuartzNet_Use
{
    public class RemindersJob : IJob
    {
        //private readonly IServiceProvider _provider;

        //public RemindersJob(IServiceProvider provider)
        //{
        //    _provider = provider;
        //}

        public Task Execute(IJobExecutionContext context)
        {
            Task.Delay(TimeSpan.FromSeconds(2));
            Console.Out.WriteLineAsync($"Time is {DateTime.Now}");

            return Task.CompletedTask;
        }
    }
}
