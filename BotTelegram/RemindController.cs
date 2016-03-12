using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotTelegram
{
    public class RemindController : Controller
    {
        public static List<string> remindComand = new List<string>() { "", "" };

        public RemindController(User user) : base(user)
        {
        }

        public override void Task(object obj)
        {
            throw new NotImplementedException();
        }
    }
}