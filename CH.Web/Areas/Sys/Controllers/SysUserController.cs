using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http; 
using CH.BLL;
using CH.Model; 
using System.Dynamic;
using System.Net;
using System.Text;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json; 
using CH.Common.Security;
using CH.Common; 
namespace CH.Web.Areas.Sys.Controllers
{
    public class SysUserController : Controller
    {
        //
        // GET: /Sys/SysUser/
        [MenuPermissionAttribute]
        public ActionResult Index()
        {

            dynamic viewModel = new ExpandoObject();
            viewModel.Name = User.Identity.Name;
            return View(viewModel);
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult IP()
        {
             
           string res=  CH.Common.RequestUrl.GetHttp("http://ip.taobao.com/service/getIpInfo2.php", "ip=myip");

           return Content(res);
        }


        [System.Web.Mvc.AllowAnonymous]
        public ActionResult  ValidUser(string username, string userpwd,string code)
        {
            string ip = string.Empty;
            
            try
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
                {
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); // Return real client IP.
                }
                else// not using proxy or can't get the Client IP
                {
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
                }  

                string[] ipinfo= CH.Common.RequestUrl.GetIp138;

                SysUserServices SysUserService = new SysUserServices();

                var cookie = this.HttpContext.Request.Cookies["imgcode"];

                if(cookie ==null)
                {
                    throw new Exception("cookies异常");
                }

                string imgcode_encry = string.Empty;

                //解密 cookies
                try
                {
                    imgcode_encry = CryptoEngine.DESProviderDecryption(cookie.Value, "imgcode");
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

                var result = SysUserService.AuthorizedUserLogin(username, userpwd, code, imgcodes_encry[0], ip, ipinfo[0], ipinfo[1], SysUserService.SigninLog);


                return new FormatJsonResult(result[0], result[1]);
            }
            catch(Exception e)
            {
                if (e.Message.Contains("连接"))
                {
                    return new FormatJsonResult("N", "数据库正在维护请稍后..");
                }
                else
                return new FormatJsonResult("N", e.Message);
            }
           

        }

    }

    public class SysUserApiController:ApiController
    {


        /// <summary>
        /// 获取用户的角色下的用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public dynamic GetRoleUser(RequestWrapper request)
        {
            SysUserServices sv = new SysUserServices();
            string rid=request.data.roleid;
            return sv.Get_ByRoleId(rid).Select(m => new { UserId = m.UserId, UserName = m.UserName });
            //return sv.Get_ByRoleId(request.data.roleid.ToString()).Select(m => );

        }
        


        /// <summary>
        /// 获取当前用户下所管理的用户
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public dynamic GetUser(RequestWrapper request, string id)
        {
           
            //var NAME = User.Identity.Name;
            dynamic data = request.data;
            //((IDictionary<string, object>)data).ContainsKey("name");
            var sysUserServices = new SysUserServices();
            int total = 0;
            List<SysUser> lst_SysUser = sysUserServices.GetUserByMaster_Page(data, id, out total);

            return new { total = total, rows = lst_SysUser };
        }
 

        /// <summary>
        /// 编辑用户 用户菜单管理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public dynamic EditUser(dynamic data,string id)
        {

            var sv = new SysUserServices();

            return sv.SaveUser(data, id);
           // return new { status = true, msg="Successful" };
        }
        

    }
}
