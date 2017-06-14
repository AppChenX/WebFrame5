using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http; 
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Converters;
using System.Web.Http.Dispatcher;
using Newtonsoft.Json;
using CH.Common;
namespace CH.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //设置时间格式
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
   new Newtonsoft.Json.Converters.IsoDateTimeConverter()
   {
       DateTimeFormat = "yyyy-MM-dd hh:mm:ss"
   })
   ;
            //忽略空数据

            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;


            //支持命名空间
            config.Services.Replace(typeof(IHttpControllerSelector),
            new NamespaceHttpControllerSelector(config));


            config.ParameterBindingRules.Insert(0, param =>
            {
                if (param.ParameterType == typeof(RequestWrapper))
                    return new RequestWrapperParameterBinding(param);

                return null;
            });


            //注册默认路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, namespaceName = new string[] { "CH.MvcWeb.Controllers" } }
            );

            //清除XML内容
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();


            config.Filters.Add(new AuthorizeAttribute());

        }
    }
}
