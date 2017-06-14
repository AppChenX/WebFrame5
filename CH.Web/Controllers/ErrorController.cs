using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CH.Web.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult PageError()
        {
            return View();
        }

        public ActionResult PageNoPermission()
        {

            return View();
        }

    }
}
