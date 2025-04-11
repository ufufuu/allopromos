using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Infrastructure.EmailConfig
{
    public class EmailConfig : //IEmailConfiguration
    {
        public string smtpServer { get; }

        public int smtpPort { get; set; }

        public string smtpUsername { get; set; }

        public string smtpPassword { get; set; }

        public string popServer { get; set; }

        public int popPort { get; set; }

        public string popUsername { get; set; }

        public string popPassword { get; set; }
    }
}
