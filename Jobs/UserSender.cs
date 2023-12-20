using Quartz;

namespace TelegeramHappyBirthday.Jobs
{
    public class UserSender : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            TGBot bot = new TGBot("6747251297:AAFoY2wLQXdgtVG0-jwvLGoSboL8Jhft-IE");
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault(u => u.HappyBirthday.Minute == DateTime.Now.Minute);
                if (user != null)
                {
                    if (user.HappyBirthday.Minute == DateTime.Now.Minute)
                    {
                        bot.Happy(user.Id);
                    }
                }
            }  
        }
    }
}
