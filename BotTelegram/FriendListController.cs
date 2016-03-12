using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotTelegram
{
    public class FriendListController : Controller
    {
        
        public FriendListController(User obj) : base(obj)
        {

        }

        public static List<string> friendListCommand = new List<string>() { "", "" };

        public override void Task(object obj)
        {
            throw new NotImplementedException();
        }
    }
}