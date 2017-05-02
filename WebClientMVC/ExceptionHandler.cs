using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CommonUtilities;

namespace WebClientMVC
{
    public class ExceptionHandler: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            var message = HttpUtility.UrlEncode(ex.Message);
            filterContext.ExceptionHandled = true;
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            ErrorLogger.LogError(ex, "Controller: " + controllerName + " Action: " + actionName);

            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Error" },
                    { "action", "Error" },
                   { "message", message}
               });
        }
    }
}