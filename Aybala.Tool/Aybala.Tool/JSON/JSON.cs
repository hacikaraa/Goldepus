using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Aybala.Tool.JSON
{
    public class Json
    {
        public static string ConvertJson(object input) 
        {
            return JsonConvert.SerializeObject(input);
        }

        public static void ConvertJson(object input,out string output)
        {
            output = JsonConvert.SerializeObject(input);
        }

        public static object ParseJson(string input)
        {
            return JsonConvert.DeserializeObject(input);
        }

        public static void ParseJson(string input, out object output)
        {
            output = JsonConvert.DeserializeObject(input);
        }

        public static T ParseJson<T>(string input)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<T>(input);
                return (T)Convert.ChangeType(data, typeof(T));
            }
            catch (Exception)
            {
                throw new Exception("Json Belirtilen Formata Çevrilemedi");
            }
            
        }

        public static void ParseJson<T>(string input, out T output) 
        {
            try
            {
                var data = JsonConvert.DeserializeObject<T>(input);
                output = (T)Convert.ChangeType(data, typeof(T));
            }
            catch (Exception)
            {
                throw new Exception("Json Belirtilen Formata Çevrilemedi");
            }
        }

    }
}
