 
using System.Web.Http;
using System.Web.Mvc; 
using CH.BLL; 
namespace CH.Web.Areas.Sys.Controllers
{
    public class SysDepartmentController : Controller
    {
        //
        // GET: /Sys/SysDepartment/

        public ActionResult Index()
        {
            return View();
        }

    }

    public class SysDepartmentApiController : ApiController
    {
        //
        // GET: /Sys/SysDepartment/

        [System.Web.Http.HttpPost]
        public dynamic PostUserDepartment(dynamic data)
        {

            string uid = data.uid;

            var sv = new SysDepartmentServices();

            return sv.GetBy_UserId(uid);


        }

          [System.Web.Http.HttpPost]
        public dynamic EditUserDepartment(dynamic data,string id)
        {
               
            var sv = new SysDepartmentServices();

            return sv.Save_UserDepartment(data, id);


        }
    }
}
