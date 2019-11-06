using System;
using System.Collections.Generic;
using System.Linq;

namespace WxLogin.Utils
{
    public static class Dictionary
    {
        public static string MyToString<TKey,TValue>(this IDictionary<TKey,TValue> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            var items = from kvp in dictionary
                select kvp.Key + "=" + kvp.Value;

            return string.Join("&", items);
        }
    }
}