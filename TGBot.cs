using Telegram.Bot;
using Telegram.Bot.Types;
namespace TelegeramHappyBirthday
{
    public class TGBot
    {
        TelegramBotClient _client;
        public TGBot(string Token)
        {
            _client = new TelegramBotClient(Token);
        }

        public void Happy(int userid)
        {
            var me = _client.GetMeAsync().Result;
            var updates = _client.GetUpdatesAsync().Result;
            if (updates != null)
            {
                foreach (var update in updates)
                {
                    PrUpdate(update, userid);
                }
            }
        }

        public void PrUpdate(Telegram.Bot.Types.Update update, int userid)
        {
            string imagePath = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                var userId = db.Users.FirstOrDefault(u => u.Id == userid);
                imagePath = Path.Combine(Environment.CurrentDirectory, "image/Happy.jpg");
                using (var stream = System.IO.File.OpenRead(imagePath))
                {
                    var r = _client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFileStream(stream)).Result;
                }
                _client.SendTextMessageAsync(update.Message.Chat.Id, $"{userId.Name} поздравляем вас с днем рождения желаем вам счастья здоровья!");  
            }   
        }
    }
}
