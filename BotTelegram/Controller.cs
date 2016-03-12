using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotTelegram
{
    public abstract class Controller
    {
        public User user;

        public Controller() { user = null; }

        public Controller(User user)
        {
            this.user = user;
        }

        abstract public void Task(Object obj); 
    }
}