using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security; 
namespace CH.Common
{
    public class FormsAuth
    {

        public static void SignIn(string userId, int expireMin)
        {
             
            //var data = JsonConvert.SerializeObject(user);
            //创建票据
            var ticket = new FormsAuthenticationTicket(2, userId, DateTime.Now, DateTime.Now.AddHours(1), true, userId);
            //加密Ticket，变成一个加密的字符串。
            var cookieValue = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue) { HttpOnly = true, Domain = FormsAuthentication.CookieDomain, Path = FormsAuthentication.FormsCookiePath, Secure = FormsAuthentication.RequireSSL };


             //FormsAuthentication.SetAuthCookie(user.Uid,false);

            if (expireMin > 0)
                cookie.Expires = DateTime.Now.AddMinutes(expireMin);

            var context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();
            //清除
            context.Response.Cookies.Remove(cookie.Name);
            //添加cookies
            context.Response.Cookies.Add(cookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }

       

    }
}
