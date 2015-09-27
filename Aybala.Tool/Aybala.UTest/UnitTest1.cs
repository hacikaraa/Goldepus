using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Aybala.UTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ErrorLogTest()
        {
            Aybala.DTO.Net.MailObject mail = new DTO.Net.MailObject();
            Aybala.DTO.Net.ReceiverObject receiver = new DTO.Net.ReceiverObject();

            Assert.IsTrue(Aybala.Tool.Logger.ErrorLog.CreateLog("Test", "test", "Deneme", 
                Tool.Logger.RegisterType.Mail, new System.Collections.Generic.List<string>() { "haci.karaarslan@nilaccra.com", "sevket.yilmaz@nilaccra.com" }));
        }

        [TestMethod]
        public void CryptologyTest()
        {
            string cry = Aybala.Tool.Cryptology.AES.Encrypt("Test", "deneme");
            string dec = Aybala.Tool.Cryptology.AES.Decrypt(cry, "deneme");

            Assert.AreEqual("Test", dec);

           
        }

        [TestMethod]
        public void ExportTest()
        {
            List<string> a = Aybala.Tool.IO.Stream.ReadFile(@"H:\test.txt");
            Console.Write(a);
            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void XmlTest()
        {
            Aybala.Tool.XML.Xml.ParseXmlData<Aybala.DTO.Net.MailObject>("<?xml version=\"1.0\" encoding=\"utf-16\"?><MailObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><MailAddress>errorlog@bariha.org</MailAddress><MailPassword>hKARA357753</MailPassword><HostName>95.173.180.170</HostName><PortNumber>587</PortNumber><EnableSsl>false</EnableSsl><UseDefaultCredentials>false</UseDefaultCredentials><IsBodyHtml>true</IsBodyHtml><Receiver><MailAddress /><Subject /><Body /></Receiver></MailObject>");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ImportTest()
        {
            //Aybala.Tool.IO.Import.ImportCsv(@"C:\Users\Haci\Desktop\Book2.csv");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CitizenTest()
        {
            var result = Aybala.Tool.Validations.CitizenNumber.IsValid("39115152414");
            Assert.IsFalse(result);
        }

    }
}
