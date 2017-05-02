using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using CommonUtilities;

namespace QuoteWizard.Filters
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        
        public override void OnException(HttpActionExecutedContext context)
        {
            var controllerName = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = context.ActionContext.ActionDescriptor.ActionName;

            ErrorLogger.LogError(context.Exception, "Controller: " + controllerName + " Action: " + actionName);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error has occurred: " + context.Exception.Message),
                ReasonPhrase = "Exception occurred"
            });
        }
    }
}