using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace GOLDEPUS.MVC.ServerSide
{
    public class CacheManager
    {
        public static void Add(string key, object obj)
        {
            Add(key, obj, 140);
        }

        public static void Add(string key, object obj, int duration)
        {
            HttpContext.Current.Cache.Add(key, obj, null, DateTime.Now.AddMinutes(duration), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        public static bool HasObject(string key)
        {
            return (HttpContext.Current != null && HttpContext.Current.Cache[key] != null && HttpContext.Current.Cache[key] != DBNull.Value);
        }

        public static object GetObject(string key)
        {
            if (HasObject(key))
                return HttpContext.Current.Cache[key];
            return null;
        }

        public static T GetObject<T>(string key) where T : class, new()
        {
            if (HasObject(key))
                return (T)HttpContext.Current.Cache[key];
            return null;
        }

        public static void Remove(string key)
        {
            if (HasObject(key))
            {
                HttpContext.Current.Cache.Remove(key);
            }
        }

        public static void Remove(params string[]  keys)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (HasObject(keys[i]))
                {
                    HttpContext.Current.Cache.Remove(keys[i]);
                }
            }
        }

        public static void Clear()
        {
            foreach (DictionaryEntry CachedObject in HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Remove(CachedObject.Key.ToString());
            }
        }


    }
}
