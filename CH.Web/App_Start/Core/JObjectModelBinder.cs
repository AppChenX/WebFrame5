using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.IO;

namespace CH.Web
{
    /// <summary>
    /// 处理POST参数为dynamic
    /// </summary>
    public class JObjectModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var stream = controllerContext.RequestContext.HttpContext.Request.InputStream;
            stream.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(stream).ReadToEnd();
            return JsonConvert.DeserializeObject<dynamic>(json);
        }
    }
}
