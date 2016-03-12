using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotTelegram
{
    public class MoneyBackController : Controller
    {
        public static List<string> moneyBackCommand = new List<string>() { "", "" };

        public MoneyBackController(User user) : base(user)
        {
        }

        public override void Task(object obj)
        {
            throw new NotImplementedException();
        }
    }
}