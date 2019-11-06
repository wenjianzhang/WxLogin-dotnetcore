using System;
using System.Net.Http;
using Newtonsoft.Json;
using WxLogin.Models;

namespace WxLogin.Utils
{
    public static class HttpHelper
    {
        public static string Get(string url)
        {
            var client = new HttpClient();
            string result = client.GetStringAsync(url).Result;
            return result;
        }
    }
}