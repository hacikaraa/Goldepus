using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.DTO.Net
{
    public class MailObject
    {
        private int portNumber;
        private string mailAddress;
        private string mailPassword;
        private string hostName;
        private bool enableSsl;
        private bool useDefaultCredentials;
        private bool isBodyHtml;
        private ReceiverObject receiver;

        public MailObject()
        {
            InitMailAccess("errorlog@bariha.org", "hKARA357753", "95.173.180.170", 587, false, false, true);
        }

        public MailObject(string mailAddress, string mailPassword, string hostName, bool enableSsl)
        {
            InitMailAccess(mailAddress, mailPassword, hostName, 587, enableSsl, false, true);
        }

        public MailObject(string mailAddress, string mailPassword, string hostName, int portName, bool enableSsl, bool useDefaultCredentials, bool isBodyHtml)
        {
            InitMailAccess(mailAddress, mailPassword, hostName, portName, enableSsl, useDefaultCredentials, isBodyHtml);
        }


        private void InitMailAccess(string mailAddress, string mailPassword, string hostName, int portNumber, bool enableSsl, bool useDefaultCredentials, bool isBodyHtml)
        {
            this.mailAddress = mailAddress;
            this.mailPassword = mailPassword;
            this.hostName = hostName;
            this.portNumber = portNumber;
            this.enableSsl = enableSsl;
            this.useDefaultCredentials = useDefaultCredentials;
            this.isBodyHtml = isBodyHtml;
            this.receiver = new ReceiverObject();
        }

        public string MailAddress
        {
            get { return this.mailAddress; }
            set { this.mailAddress = value; }
        }

        public string MailPassword
        {
            get { return this.mailPassword; }
            set { this.mailPassword = value; }

        }

        public string HostName
        {
            get { return this.hostName; }
            set { this.hostName = value; }
        }

        public int PortNumber
        {
            get { return this.portNumber; }
            set { this.portNumber = value; }
        }

        public bool EnableSsl
        {
            get { return this.enableSsl; }
            set { this.enableSsl = value; }
        }

        public bool UseDefaultCredentials
        {
            get { return this.useDefaultCredentials; }
            set { this.useDefaultCredentials = value; }
        }

        public bool IsBodyHtml
        {
            get { return this.isBodyHtml; }
            set { this.isBodyHtml = value; }
        }

        public ReceiverObject Receiver
        {
            get { return this.receiver; }
            set { this.receiver = value; }
        }
    }
}

