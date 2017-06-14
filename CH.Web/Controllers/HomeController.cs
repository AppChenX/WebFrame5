using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
namespace CH.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/


        [AllowAnonymous]
        public ActionResult Test()
        {
            return View();
        }
        
        public ActionResult Index()
        {

            //通过 ID获取角色

            var sv = new CH.BLL.SysRoleServices();
            var item = sv.GetByUserId(User.Identity.Name).FirstOrDefault() ;

            ViewBag.Role =item==null?null: item.RoleName;
            return View();
        }

    }
}
