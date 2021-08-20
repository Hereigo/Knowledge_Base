using System;

namespace QuartzNet_Use
{
    public class JobSchedule
    {
        public Type JobType { get; }

        public JobSchedule(Type jobType)
        {
            JobType = jobType;
        }
    }
}
