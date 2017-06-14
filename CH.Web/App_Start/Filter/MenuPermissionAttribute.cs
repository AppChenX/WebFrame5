using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CH.BLL;
using CH.Model;
namespace CH.Web 
{

    /// <summary>
    /// 菜单权限
    /// </summary>
    public class MenuPermissionAttribute : ActionFilterAttribute
    {
         

        /// <summary>
        /// 拦截菜单权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var m = filterContext.RouteData.DataTokens;



            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {

                //获取当前角色菜单
                string UserName=filterContext.HttpContext.User.Identity.Name;

                string Action = filterContext.ActionDescriptor.ActionName;

                string Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                object Area = filterContext.RouteData.DataTokens["area"]; 

                SysMenuServices sv = new SysMenuServices();

                var List_Menu= sv.GetMenuByUid(UserName);


                string targetUrl = string.Format("{0}/{1}/{2}", Area==null?"":string.Format("/{0}",Area), Controller, Action);
                 

                var permPage = List_Menu.Where(m =>!string.IsNullOrEmpty(m.MenuUrl)&& m.MenuUrl.ToUpper() == targetUrl.ToUpper()).Select(m => m.MenuUrl).FirstOrDefault();

                if (permPage == null)
                //调转到权限不足页面
                filterContext.Result = new RedirectResult("~/Error/PageNoPermission");
                

            } 

            //判定当前权限

            base.OnActionExecuting(filterContext);
        }

    }
}