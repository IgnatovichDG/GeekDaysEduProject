using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EduBot.Models
{
    public static class Methods
    {
        private static int GetTime(string time)
        {
            if (time.IndexOf(":", StringComparison.Ordinal) == 3)
            {
                return int.Parse(time.Substring(0, 2));
            }
            else
            {
                return int.Parse(time.Substring(0, 1));
            }
        }

        public static List<string> GetLastTasks(string user)
        {
            using (var context = new geekdaysEntities_new())
            {
                var schedules = context.Schedules
                    .Where(l => l.Link.UserId == user)
                    .Include(s => s.Link)
                    .Include(s => s.Link.ResourceModel)
                    .ToList();
                List<string> kek = new List<string>();
                foreach (var schedulese in schedules)
                {
                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                            if (schedulese.Day == "Воскресенье" && GetTime(schedulese.Time) - DateTime.Now.Hour < 2)
                                kek.Add(
                                    $"Tы собирался изучать {context.Links.First(l => l.LinkId == schedulese.Link_LinkId).ResourceModel.Name} сегодня в {schedulese.Time}!");
                            break;
                        case DayOfWeek.Monday:
                            if (schedulese.Day == "Понедельник" && GetTime(schedulese.Time) - DateTime.Now.Hour < 2)
                                kek.Add(
                                    $"Tы собирался изучать {context.Links.First(l => l.LinkId == schedulese.Link_LinkId).ResourceModel.Name} сегодня в {schedulese.Time}!");
                            break;
                        case DayOfWeek.Tuesday:
                            if (schedulese.Day == "Вторник" && GetTime(schedulese.Time) - DateTime.Now.Hour < 2)
                                kek.Add(
                                    $"Tы собирался изучать {context.Links.First(l => l.LinkId == schedulese.Link_LinkId).ResourceModel.Name} сегодня в {schedulese.Time}!");
                            break;
                        case DayOfWeek.Wednesday:
                            if (schedulese.Day == "Среда" && GetTime(schedulese.Time) - DateTime.Now.Hour < 2)
                                kek.Add(
                                    $"Tы собирался изучать {context.Links.First(l => l.LinkId == schedulese.Link_LinkId).ResourceModel.Name} сегодня в {schedulese.Time}!");
                            break;
                        case DayOfWeek.Thursday:
                            if (schedulese.Day == "Четверг" && GetTime(schedulese.Time) - DateTime.Now.Hour < 2)
                                kek.Add(
                                    $"Tы собирался изучать {context.Links.First(l => l.LinkId == schedulese.Link_LinkId).ResourceModel.Name} сегодня в {schedulese.Time}!");
                            break;
                        case DayOfWeek.Friday:
                            if (schedulese.Day == "Пятница" && GetTime(schedulese.Time) - DateTime.Now.Hour < 2)
                                kek.Add(
                                    $"Tы собирался изучать {context.Links.First(l => l.LinkId == schedulese.Link_LinkId).ResourceModel.Name} сегодня в {schedulese.Time}!");
                            break;
                        case DayOfWeek.Saturday:
                            if (schedulese.Day == "Суббота" && GetTime(schedulese.Time) - DateTime.Now.Hour < 2)
                                kek.Add(
                                    $"Tы собирался изучать {context.Links.First(l => l.LinkId == schedulese.Link_LinkId).ResourceModel.Name} сегодня в {schedulese.Time}!");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                return kek;
            }
        }
        private static string _apiKey = "241526981:AAENMSik5lUBcKzscuiAGPNaINXg4Pb6l7Y";

        public static void SendDeadlinesInLoop()
        {
            while (true)
            {
                List<LinkChatUser> links;
                using (var db = new geekdaysEntities_new())
                {
                    links = db.LinkChatUsers.ToList();
                }
                foreach (var linkChatUser in links)
                {
                    SendDeadlines(linkChatUser.UserId, linkChatUser.ChatId);
                }
                Task.Delay(600000).Wait();
            }
        }

        public static void SendDeadlines(string userId, int chatId)
        {
            var deadlines = GetLastTasks(userId);
            foreach (var deadline in deadlines)
            {
                new HttpClient().GetAsync(
                $"https://api.telegram.org/bot{_apiKey}/sendmessage?chat_id={chatId}&text={deadline}");
            }
        }
    }
}