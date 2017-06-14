using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
namespace CH.Web
{


    /// <summary>
    /// API操作权限
    /// </summary>
    public class ApiPermissionAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var route = actionContext.ControllerContext.RouteData;

            var action= route.Values["action"];
            var controller = route.Values["controller"];
            var area = route.Values["area"];
           
            //没有权限

            //var resp = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            //resp.Content = new StringContent(JsonConvert.SerializeObject(new{ status=false,msg="无此操作的权限"}), Encoding.GetEncoding("UTF-8"), "application/json");
            //actionContext.Response = resp;


            base.OnActionExecuting(actionContext);
        }
    }
}