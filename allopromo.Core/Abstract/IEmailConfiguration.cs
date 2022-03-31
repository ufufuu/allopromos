namespace allopromo.Core.Infrastructure.Abstract
{
    public class EmailConfiguration:IEmailConfiguration
    {
        //SMTP
        public string smtpServer { get; }
        public int smtpPort { get; set; }
        public string smtpUsername { get; set; }
        public string smtpPassword { get; set; }

        //POP
        public string popServer { get; set; }
        public int popPort { get; set; }
        public string popUsername { get; set; }
        public string popPassword { get; set; }
    }
    public  interface IEmailConfiguration 
    {
        //SMTP
        string smtpServer { get; }
        int smtpPort { get; }
        string smtpUsername { get; }
        string smtpPassword { get; }

        //POP
        string popServer { get; }
        int popPort { get; }
        string popUsername { get; }
        string popPassword { get; }
    }
}
//? What is Internal interface ?