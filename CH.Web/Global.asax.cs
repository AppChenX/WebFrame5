using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CH.Web.Controllers;
using log4net;
using System.Reflection;
namespace CH.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

       
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var exp = Server.GetLastError();
            var httpException = exp as HttpException ?? new HttpException(500, "服务器内部错误", exp);

            Response.Clear();
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");

            switch (httpException.GetHttpCode())
            {
                case 404:
                    routeData.Values.Add("action", "PageNotFound");
                    break;

                default:
                    routeData.Values.Add("action", "PageError");
                    //routeData.Values.Add("httpStatusCode", httpException.GetHttpCode());
                    break;
            }

            Server.ClearError();

            var controller = new ErrorController();
            controller.ViewData.Model = exp;
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error(exp.Message);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}
