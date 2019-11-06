using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WxLogin.Models;
using WxLogin.Utils;

namespace WxLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WXController : Controller
    {
        // GET
        // https://open.weixin.qq.com/connect/qrconnect?appid=wxff26f000ea89ecd8&redirect_uri=http://www.englishbeans.cn/api/wxlogin&response_type=code&scope=snsapi_login,snsapi_base,snsapi_userinfo&state=STATE#wechat_redirect 
        [HttpGet]
        public IActionResult AccessToken(String code)
        {
            //https://api.weixin.qq.com/sns/oauth2/access_token?appid=APPID&secret=SECRET&code=CODE&grant_type=authorization_code
            var accessToken = WXSDK.GetAccessToken(code);
            
            
            //https://api.weixin.qq.com/sns/userinfo?access_token=27_lHSLehasNfuyuBJqMTteOVKEBkWEnajIgVcAx0p9Vh4AMlUnIe17YoVy0hJtoFP2S88QcS-F1SB1kfbYi5LPTu1-cHZfcJrmzd9QFSUUUG8&openid=oE2RCwsWY3WM0Xr9CWfvXJuazzB0
            var refreshToken = WXSDK.GetUserInfo(accessToken.access_token, accessToken.openid);
            
            return Ok(accessToken);
        }
        
        [HttpGet]
        public IActionResult RefreshToken(String refresh_token,string openid)
        {
            //https://api.weixin.qq.com/sns/userinfo?access_token=27_lHSLehasNfuyuBJqMTteOVKEBkWEnajIgVcAx0p9Vh4AMlUnIe17YoVy0hJtoFP2S88QcS-F1SB1kfbYi5LPTu1-cHZfcJrmzd9QFSUUUG8&openid=oE2RCwsWY3WM0Xr9CWfvXJuazzB0
            var refreshToken = WXSDK.GetRefreshToken(refresh_token, openid);
            
            return Ok(refreshToken);
        }
        
        [HttpGet]
        public IActionResult UserInfo(String access_token,string openid)
        {
            //https://api.weixin.qq.com/sns/userinfo?access_token=27_lHSLehasNfuyuBJqMTteOVKEBkWEnajIgVcAx0p9Vh4AMlUnIe17YoVy0hJtoFP2S88QcS-F1SB1kfbYi5LPTu1-cHZfcJrmzd9QFSUUUG8&openid=oE2RCwsWY3WM0Xr9CWfvXJuazzB0
            var refreshToken = WXSDK.GetUserInfo(access_token, openid);
            
            return Ok(refreshToken);
        }
    }
    

   

    
}