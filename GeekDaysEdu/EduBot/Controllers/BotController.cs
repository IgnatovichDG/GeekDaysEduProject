using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EduBot.Models;

namespace EduBot.Controllers
{
    public class BotController : ApiController
    {
        private string _apiKey = "241526981:AAENMSik5lUBcKzscuiAGPNaINXg4Pb6l7Y";
        // GET: Bot
        public IHttpActionResult Post(Update upd)
        {
            string reply;
            if (upd.Message.Text.StartsWith("/start"))
                reply = "Пожалуйста, предоставьте email-адрес, который Вы использовали при регистрации.";
            else if (upd.Message.Text.Contains("@"))
            {
                try
                {
                    string userId;
                    using (var db = new geekdaysEntities_new())
                    {
                        userId = db.AspNetUsers.FirstOrDefault(u => u.UserName == upd.Message.Text)?.Id;
                        db.LinkChatUsers.Add(new LinkChatUser()
                        {
                            ChatId = upd.Message.Chat.Id,
                            UserId = userId
                        });
                        db.SaveChanges();
                    }
                    reply = "Спасибо. Ждите оповещений!";

                    Methods.SendDeadlines(userId, upd.Message.Chat.Id);
                }
                catch (Exception e)
                {
                    reply = "Error!" + e.Message;
                }
                
            }
            else
                reply = "Я жду от Вас email-адрес.";
            

            new HttpClient().GetAsync(
                    $"https://api.telegram.org/bot{_apiKey}/sendmessage?chat_id={upd.Message.Chat.Id}&text={reply}");

            return Ok();
        }
    }
}