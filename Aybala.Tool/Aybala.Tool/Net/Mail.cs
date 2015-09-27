using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aybala.DTO.Net;
using System.Net.Mail;

namespace Aybala.Tool.Net
{
    public class Mail
    {
        private Mail() { }

        public static bool Send(string mail, string subject, string body) 
        {
            ReceiverObject receiver = new ReceiverObject();
            receiver.MailAddress = mail;
            receiver.Subject = subject;
            receiver.Body = body;
            return Send(new MailObject() { Receiver = receiver });
        }

        public static bool Send(ReceiverObject receiver)
        {
            return Send(new MailObject() { Receiver = receiver });
        }

        public static bool Send(MailObject mailObject) 
        {
            bool result = false;
            try
            {
                MailMessage newMail = new MailMessage();
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                newMail.Subject = mailObject.Receiver.Subject;
                newMail.Body = mailObject.Receiver.Body;
                newMail.From = new MailAddress(mailObject.MailAddress);
                foreach (var item in mailObject.Receiver.MailAddress.Split(','))
                    newMail.To.Add(item);
                newMail.IsBodyHtml = mailObject.IsBodyHtml;
                client.Host = mailObject.HostName;
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential(mailObject.MailAddress, mailObject.MailPassword);
                client.Port = mailObject.PortNumber;
                client.EnableSsl = mailObject.EnableSsl;
                client.UseDefaultCredentials = mailObject.UseDefaultCredentials;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(newMail);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
