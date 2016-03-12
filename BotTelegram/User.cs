using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotTelegram
{
    public class User : Person
    {
        public int chat_id { get; set; }

        public User(int id)
        {
            chat_id = id;
        }

        //public FriendList FriendList
        

        //public MyLoansRegister MyLoansRegister
        

        //public DebtorList DebtorList
        
    }
}