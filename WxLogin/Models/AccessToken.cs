namespace WxLogin.Models
{
    public class AccessToken : RefreshToken
    {
        public string unionid { get; set; }
    }

    public class RefreshToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }

    public class UserInfo
    {
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public string[] privilege { get; set; }
        public string unionid { get; set; }
    }

    public class ErrorInfo
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}