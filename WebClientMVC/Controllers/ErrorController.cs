using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientMVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error(string message)
        {
            ViewBag.ApplicationError = HttpUtility.UrlDecode(message);
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult InternalError()
        {
            return View();
        }
    }
}