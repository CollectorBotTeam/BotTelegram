using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegram
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageManager manager = new MessageManager();
            while(true)
            {
                manager.Update();
            }
        }
    }
}
