using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;


namespace BotTelegram
{
    enum ListNumber
    {
        initCommand,
        friendListCommand,
        askMoneyCommand,
        moneyBackCommand,
        remindComand,
        notCommand
    }

    public class MessageManager
    {
        #region static
        static public void SendMessage(string text, User user)
        {
            Method = "sendmessage?";
            var webRequest = (HttpWebRequest)WebRequest.Create(
                String.Format("{0}{1}/{2}chat_id={3}&text={4}", Telegram, Token, Method, user.chat_id, text));
            var httpResponse = (HttpWebResponse)webRequest.GetResponse();
            webRequest.Abort();
        }
        #endregion

        #region Properties

        static string Token
        { get; set; }

        static string Method
        { get; set; }

        const string Telegram = "https://api.telegram.org/bot";

        UpdateObject UPDList = null;

        int messageCount { get; set; }

        #endregion

        #region Constructors
        public MessageManager()
        {
            Token = "188555203:AAHfCIHbydFjvhAiLkUtu-zXQ-KvQqFhGss";
            GetAllMessages();
            messageCount = UPDList.result.Count;
        }
        #endregion

        public void Update()
        {
            Message newMessage = GetNextMessage();

            //check ignore list as newMessage from

            if (newMessage != null)
            {
                User user = new User(newMessage.chat.id);
                ListNumber num = resolveCommand(newMessage.text);
                Controller controller = null;

                switch (num)
                {
                    case ListNumber.initCommand:
                        controller = new InitializeController(user);
                        break;
                    case ListNumber.friendListCommand:
                        controller = new FriendListController(user);
                        break;
                    case ListNumber.askMoneyCommand:
                        controller = new AskMoneyController(user);
                        break;
                    case ListNumber.moneyBackCommand:
                        controller = new MoneyBackController(user);
                        break;
                    case ListNumber.remindComand:
                        controller = new RemindController(user);
                        break;
                    case ListNumber.notCommand:
                        SendMessage("Wrong command! use /help to see the instruction!", user);
                        break;
                }

                if (controller != null)
                {
                    doTask(controller);
                }
            }

        }

        void doTask(Controller controller)
        {
            new Thread(controller.Task).Start();
        }

        Message GetNextMessage()
        {
            GetAllMessages();
            if (UPDList.result.Count > messageCount)
            {
                messageCount = UPDList.result.Count;
                return UPDList.result.Last().message;
            }
            else
            {
                return null;
            }
        }

       public void GetAllMessages()
        {
            Method = "getupdates";
            var httpWebRequest = (HttpWebRequest)WebRequest.CreateHttp(Telegram + Token + "/" + Method);


            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //ответ от сервера
                var result = streamReader.ReadToEnd();

                UPDList = JsonConvert.DeserializeObject<UpdateObject>(result);
                httpWebRequest.Abort();

            }

        }

        ListNumber resolveCommand(string command)
        {
            ListNumber answer = ListNumber.notCommand;
            if (InitializeController.initCommands.Contains(command))
            {
                answer = ListNumber.initCommand;
            }
            else if (FriendListController.friendListCommand.Contains(command))
            {
                answer = ListNumber.friendListCommand;
            }
            else if (AskMoneyController.askMoneyCommand.Contains(command))
            {
                answer = ListNumber.askMoneyCommand;
            }
            else if (MoneyBackController.moneyBackCommand.Contains(command))
            {
                answer = ListNumber.moneyBackCommand;
            }
            else if (RemindController.remindComand.Contains(command))
            {
                answer = ListNumber.remindComand;
            }
            return answer;
        }
    }

}