using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using CH.BLL;
using CH.Model;
using Newtonsoft.Json.Linq;
using CH.Common;
namespace CH.Web.Areas.Sys.Controllers
{
    public class SysActionController : Controller
    {
        //
        // GET: /Sys/SysAction/

        public ActionResult Index()
        {
            return View();
        }

    }

    public class SysActionApiController : ApiController
    {

         [System.Web.Http.HttpGet]
        public IEnumerable<dynamic> GetSysAction(RequestWrapper request,string id)
        {

            var sv = new SysActionServices();

            return sv.GetBy_MenuId(id);


        }


         /// <summary>
         /// 保存菜单数据
         /// </summary>
         /// <param name="data"></param>
         /// <returns></returns>
         [System.Web.Http.HttpPost]
         public dynamic EditAction(dynamic data,string id)
         {


             var sv = new SysActionServices();

             return sv.SaveAction(data,id);

             
         }


          /// <summary>
          /// 保存菜单按钮权限
          /// </summary>
          /// <param name="data"></param>
          /// <param name="id"></param>
          /// <returns></returns>
         [System.Web.Http.HttpPost]
         public dynamic EditActionRole(dynamic data, string id)
         {


             var sv = new SysActionServices();

             return sv.SaveActionRole(data, id);


         }





    }
}
