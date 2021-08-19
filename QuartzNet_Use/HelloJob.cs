using System;
using System.Threading.Tasks;
using Quartz;

namespace QuartzNet_Use
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            await Console.Out.WriteLineAsync($"Time is {DateTime.Now}");
        }
    }
}
