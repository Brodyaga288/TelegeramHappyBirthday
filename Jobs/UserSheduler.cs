using Quartz.Impl;
using Quartz;

namespace TelegeramHappyBirthday.Jobs
{
    public class UserSheduler
    {
        public async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<UserSender>().Build();

            ITrigger trigger = TriggerBuilder.Create() 
                .WithIdentity("trigger1", "group1") 
                .StartNow()   
                .WithSimpleSchedule(x => x    
                                   .RepeatForever()
                                   .WithIntervalInMinutes(1))   
                .Build();                              

            await scheduler.ScheduleJob(job, trigger);     
        }
    }
}
