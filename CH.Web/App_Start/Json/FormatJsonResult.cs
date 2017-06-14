using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web; 
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
namespace CH.Web
{
    public class FormatJsonResult:ActionResult
    {

        public FormatJsonResult():base()
        {

            
        }

        public FormatJsonResult(string status, object msg)
            : this()
        {
            this.status = status;
            this.msg = msg;

        }
        
        public string status { get; set; }


        public object msg { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context.HttpContext == null)
                throw new Exception("HttpContext is null!");

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = "application/json";

            StringWriter sw = new StringWriter();

            JsonSerializer serilizer = JsonSerializer.Create(new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });

            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                serilizer.Serialize(jw, this);
            }

            response.Write(sw.ToString());
        }

    }





    
}
