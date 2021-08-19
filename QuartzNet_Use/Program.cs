using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace QuartzNet_Use
{
    public static class Program
    {
        const string groupName = "group1";
        const string jobName = "job1";
        const string triggerName = "trigger1";

        private static async Task Main(string[] args)
        {
            var n = DateTime.Now;

            DateTime startTime = new DateTime(n.Year, n.Month, n.Day, 21, 49, 0, 0);

            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            // Grab the Scheduler instance from the Factory and start it off
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity(jobName, groupName)
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(triggerName, groupName)
                      //.WithDailyTimeIntervalSchedule(s => s
                      //    .WithIntervalInHours(24)
                      //    .OnEveryDay()
                      //    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(20, 50)))

                      .StartAt(new DateTimeOffset(startTime))
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())

              //.StartNow()
              //.WithDailyTimeIntervalSchedule
              //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(20, 26))
              // .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
              .Build();

            // Tell quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);

            // some sleep to show what's happening
            // await Task.Delay(TimeSpan.FromSeconds(60));

            // and last shut down the scheduler when you are ready to close your program
            //await scheduler.Shutdown();

            //Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
