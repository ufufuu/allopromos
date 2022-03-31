using allopromo.Core.Model;
using System.Collections.Generic;
namespace allopromo.Core.Infrastructure
{
    public class EmailMessage
    {
        //public List<User> ToAdresses { get; set; }

        public List<EmailAdress> ToAdresses { get; set; }

        public string FromAdress { get; set; }
        public string messageSubject { get; set; }
        public string messageContent { get; set; }
        public EmailMessage()
        {
            ToAdresses = new List<EmailAdress>();
            FromAdress = "promos@allopromo.co";
        }
    }
    public class EmailAdress
    {
        public string userName { get; set; }
        public string userAdress { get; set; }
    }
}