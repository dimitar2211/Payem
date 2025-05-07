using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payem.Data;
using Payem.Models;

namespace Payem.Controllers
{
    public class MessageController : Controller
    {
        // Списък, който ще държи съобщенията временно
        private static List<Message> messages = new List<Message>();

        // Страница за съобщения
        public IActionResult Index()
        {
            // Премахваме съобщения, по-стари от 24 часа
            messages = messages
                .Where(m => m.CreatedAt > DateTime.Now.AddHours(-24))
                .ToList();

            return View("~/Views/Messages/Index.cshtml", messages);

        }

        // Добавяне на ново съобщение
        [HttpPost]
        public IActionResult SendMessage(string name, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                messages.Add(new Message
                {
                    Name = string.IsNullOrEmpty(name) ? "Anonymous" : name,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    Likes = 0
                });
            }

            return RedirectToAction("Index");
        }

        // Харесване на съобщение
        [HttpPost]
        public IActionResult LikeMessage(int messageId)
        {
            if (messageId >= 0 && messageId < messages.Count)
            {
                messages[messageId].Likes++;
            }

            return RedirectToAction("Index");
        }
    }
}
