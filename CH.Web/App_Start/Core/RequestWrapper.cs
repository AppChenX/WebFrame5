using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web.Http;
using System.Web.Http.Controllers;
namespace CH.Web
{
    public class RequestWrapper 
    {


        public dynamic data { get; private set; }

        //public NameValueCollection Val { get; set; }
        public RequestWrapper(NameValueCollection val)
        {
             data = new DynamicParameters();

            foreach(string m in val.Keys)
            {
                data.set(@m, val[m]);
            }
           
        }
    }
}
