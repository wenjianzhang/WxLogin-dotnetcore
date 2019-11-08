using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WxLogin.Models;

namespace WxLogin.Utils
{
    public class WXSDK
    {
        private static string appid = "appid";
        private static string secret = "secret";

        private static string base_url = "https://api.weixin.qq.com/";
        private static string get_access_token = base_url + "sns/oauth2/access_token";
        private static string get_user_info = base_url + "sns/userinfo";
        private static string get_refresh_token = base_url + "sns/oauth2/refresh_token";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static AccessToken GetAccessToken(string code)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("appid", appid);
            dictionary.Add("secret", secret);
            dictionary.Add("code", code);
            dictionary.Add("grant_type", "authorization_code");
            string para = dictionary.MyToString();
            String url = get_access_token + "?" + para;
            var accessTokenStr = HttpHelper.Get(url);
            return JsonConvert.DeserializeObject<AccessToken>(accessTokenStr);
        }

        public static RefreshToken GetRefreshToken(string refresh_token)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("appid", appid);
            dictionary.Add("refresh_token", refresh_token);
            dictionary.Add("grant_type", "refresh_token");
            string para = dictionary.MyToString();
            String url = get_refresh_token + "?" + para;
            var refreshTokenStr = HttpHelper.Get(url);
            return JsonConvert.DeserializeObject<RefreshToken>(refreshTokenStr);
        }

        public static UserInfo GetUserInfo(string access_token, string openid)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("access_token", access_token);
            dictionary.Add("openid", openid);
            string para = dictionary.MyToString();
            String url = get_user_info + "?" + para;
            var userInfoStr = HttpHelper.Get(url);
            return JsonConvert.DeserializeObject<UserInfo>(userInfoStr);
        }
    }
}
