using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace Aybala.Tool.IO
{
    public class Stream
    {
        private Stream() { }

        public static bool WriteFile(string filePath,string data)
        {
            return WriteFile(filePath, data, false);
        }

        public static bool AppendFile(string filePath, string data)
        {
            return WriteFile(filePath, data, true);
        }

        private static bool WriteFile(string filePath, string data,bool isAppend)
        {
            bool result = false;
            try
            {
                StreamWriter file = new StreamWriter(filePath,isAppend);
                file.WriteLine(data);
                file.Close();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Dosya Yazdırma İşlemin Gerçekleştirilemedi. Hata : " + ex.Message);
            }
            return result;
        }

        public static List<string> ReadFile(string filePath)
        {
            List<string> lines = new List<string>();
            try
            {
                StreamReader file = File.OpenText(filePath);
                string line;
                while (true)
                {
                    line = file.ReadLine();
                    if (line == null)
                        break;
                    lines.Add(line);
                }
                file.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Dosya Okuma İşlemin Gerçekleştirilemedi. Hata : " + ex.Message);
            }
            return lines;
        }
        
    }
}
