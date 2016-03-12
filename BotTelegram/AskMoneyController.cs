using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotTelegram
{
    public class AskMoneyController : Controller
    {
        public static List<string> askMoneyCommand = new List<string>() { "", "" };

        public AskMoneyController(User user) : base(user)
        {
        }

        public override void Task(object obj)
        {
            throw new NotImplementedException();
        }
    }
}