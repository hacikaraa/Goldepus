using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.DTO.Net
{
    public class ReceiverObject
    {
        private string mailAddress;
        private string subject;
        private string body;
        public ReceiverObject()
        {
            this.mailAddress = string.Empty;
            this.subject = string.Empty;
            this.body = string.Empty;
        }

        public string MailAddress
        {
            get { return this.mailAddress; }
            set { this.mailAddress = value; }
        }

        public string Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }

        public string Body
        {
            get { return this.body; }
            set { this.body = value; }
        }
    }
}
