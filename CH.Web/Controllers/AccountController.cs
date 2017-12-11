using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Security.Cryptography;
using System.Text;
using System.IO;
using CH.BLL;
using CH.Model;
using CH.Common;
using CH.Common.Security;
namespace CH.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        /// <summary>
        /// 忘记密码界面
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult ForgetPwd()
        {
            return View();
        }


        /// <summary>
        /// 用户token过期
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult UserTokenExpired()
        {
            return View();
        }

        
        /// <summary>
        /// 用户通过邮件修改密码界面
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult PwdReset(string token)
        {
            string _token = string.Empty;
            //判断token是否过期
            if (!string.IsNullOrEmpty(token))
            {

                try
                {
                    _token = CryptoEngine.DESProviderDecryption(token, "token");

                }
                catch
                {
                    return View("UserTokenExpired");
                }
                string[] _tokens = _token.Split(new string[] { "&" }, StringSplitOptions.None);

                double now = DateTime.Now.ToTimestamp();

                if (now > Convert.ToDouble(_tokens[1]) + Convert.ToDouble(_tokens[2]))
                {
                    return View("UserTokenExpired");
                }

                else
                {
                    ViewBag.token = token;
                    return View();
                }
            }

            else    return View("UserTokenExpired"); 
        }




        /// <summary>
        /// 通过邮件找回密码，验证码不安全应加token验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        /// <param name="verifyCode"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgetPwd(string userName, string userEmail, string verifyCode)
        {


            var msg = new StatusMessage();

            var sv = new SysUserServices();

            var cookies = this.HttpContext.Request.Cookies["imgcode"];

            string imgcode_encry = string.Empty;

            try
            {


                //解密 cookies
                try
                {
                    imgcode_encry = CryptoEngine.DESProviderDecryption(cookies.Value, "imgcode");
                }
                catch
                {
                    throw new Exception("非法的cookies");
                }


                string[] imgcodes_encry = imgcode_encry.Split(new string[] { "&" }, StringSplitOptions.None);

                double now = DateTime.Now.ToTimestamp();

                if (now > Convert.ToDouble(imgcodes_encry[1]) + Convert.ToDouble(imgcodes_encry[2]))
                {
                    throw new Exception("请刷新验证码");
                }




                msg = sv.ForgetPwd(userName, userEmail, verifyCode, imgcodes_encry[0], () =>
               {


                   //生成密码链接 设置过期时间10分钟。
                   string token = string.Format("{0}&{1}&{2}", userName, DateTime.Now.ToTimestamp(), 30 * 60);

                   token = CryptoEngine.DESProviderEncryption(token, "token");
                   string url = Url.Action("PwdReset", "Account", new { token = token }, "http");
                   string content = string.Format("用户密码找回<a href=\"{0}\" target=\"_blank\">{0}</a> <br> 此链接30分钟后失效请尽快修改密码", url);

                    EmailSender email = new   EmailSender("cl273168121", "admin151034");

                   email.sendMail("SMTP.163.com", "cl273168121@163.com", "系统管理员", userEmail, "", "系统找回密码", content, "");
               });

                 return Json(msg);
            }
              catch( Exception ex)
            {

                return Json(new StatusMessage("N", ex.Message));
            }
          
          
            //如果找到邮件地址和用户名则发送邮件
              
            
        } 
       

        /// <summary>
        /// 邮件发送成功页面
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult EmailSuccess()
        {
            return View();
        }
         
      
     

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuth.SignOut();
            return RedirectToAction("Login");
        }


        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
         [AllowAnonymous]
        public ActionResult VerifCode()
        {

            VerificationCode code = new VerificationCode();

            var m = code.GenerateCodeImg();

            return File(m.ToArray(), @"image/jpeg");
        }


    }
}
