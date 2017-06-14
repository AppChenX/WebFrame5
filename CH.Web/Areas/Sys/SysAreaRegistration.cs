using System.Web.Mvc;
using System.Web.Http.Routing;
using System.Web.Http;
using CH.Common;
namespace CH.Web.Areas.Sys
{
    public class SysAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sys";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "Sys_default",
            //    "Sys/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);

              context.MapRoute(
                this.AreaName + "default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "CH.Web.Areas." + this.AreaName + ".Controllers" }
            );

              GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                 this.AreaName + "Api",
                 "api/" + this.AreaName + "/{controller}/{action}/{id}",
                 new { area = this.AreaName, action = RouteParameter.Optional, id = RouteParameter.Optional, namespaceName = new string[] { string.Format("CH.Web.Areas.{0}.Controllers", this.AreaName) } },
                 new { action = new StartWithConstraint() });


              //////// http://localhost:39638/api/test/TestApi/1   TestApiController
        }
    }
}
