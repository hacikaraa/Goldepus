using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Aybala.Tool.XML
{
    public class Xml
    {
        public static bool CreateXmlFile<T>(T input)
        {
            bool result = false;
            try
            {
                string xmlData = ConvertXml<T>(input);
                System.Windows.Forms.SaveFileDialog fileDialog = new System.Windows.Forms.SaveFileDialog();
                fileDialog.Filter = "xml Dosyaları (*.xml)|*.xml";

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(fileDialog.FileName, false, System.Text.Encoding.GetEncoding(1254));
                    file.Write(xmlData);
                    file.Close();
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Xml Dosyası Oluşturulamadı. Hata : " + ex.Message);
            }
            return result;
        }

        public static string ConvertXml<T>(T input)
        {
            string output = string.Empty;
            try
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                StringWriter sww = new StringWriter();
                XmlWriter writer = XmlWriter.Create(sww);
                xsSubmit.Serialize(writer, input);
                output = sww.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Xml Oluşturulamadı. Hata : " + ex.Message);
            }
            return output;
        }

        public static T ParseXmlData<T>(string xmlData) 
        {
            T output;
            ParseXmlData<T>(xmlData, out output);
            return output;
        }

        public static void ParseXmlData<T>(string xmlData, out  T output)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringReader rdr = new StringReader(xmlData);
                output = (T)serializer.Deserialize(rdr);
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Xml Parse Edilemedi. Hata : " + ex.Message);
            }
        }

        public static T ParseXmlFile<T>(string xmlpath)
        {
            T output;
            ParseXmlFile<T>(xmlpath, out output);
            return output;
        }

        public static void ParseXmlFile<T>(string xmlpath, out T output)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(xmlpath);
                output = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Xml Parse Edilemedi. Hata : " + ex.Message);
            }
        }

    }
}