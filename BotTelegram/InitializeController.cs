using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotTelegram
{
    public class InitializeController : Controller
    {
        public static List<string> initCommands = new List<string>() { "", "" };

        public InitializeController(User user) : base(user)
        {
        }

        public override void Task(object obj)
        {
            throw new NotImplementedException();
        }
    }
}