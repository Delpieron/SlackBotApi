using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualDesk.Contracts
{
    public static class ApiRoutes
    {
        public const string Base = "api/v1/";

        public static class Users
        {
            public const string Add = Base + "users";
            public const string Login = Base + "users/login";
            public const string LoginSwagger = Base + "users/login/swagger";
        }
        public static class Word2PFD
        {
            public const string Word2PFD_ = Base + "Word2PFD";
        }
        public static class MailSender
        {
            public const string MailSender_ = Base + "MailSender";
        }
        public static class SlackBot
        {
            public const string SlackBot_ = Base + "SlackBot";
            public const string SlackBotMsg = Base + "SlackBot/msg";
            public const string SlackBotFile = Base + "SlackBot/file";
            public const string SlackBotMessages = Base + "SlackBot/{channel}";

        }


    }
}
