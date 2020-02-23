using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace FennyFeeds.HelperClasses
{

    public class SessionTimeout : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int User_ID = Convert.ToInt32(SessionObject.userid ?? 0);
            if (User_ID == 0)
            {
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        // put whatever data you want which will be sent
                        // to the client
                        Action = "Session_Expire",
                        message = "Sorry, you were logged out, Please login again."
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                //{
                //    action = "Signup",
                //    controller = "Account",
                //    area = ""
                //}));


                //filterContext.Result = new RedirectResult("~/Account/Signup");
                //return;
            }
            base.OnActionExecuting(filterContext);
        }
    }


    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //public class MyAuthorizeAttribute : AuthorizeAttribute
    //{
    //    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    //    {
    //        if (filterContext.HttpContext.Request.IsAjaxRequest())
    //        {
    //            filterContext.Result = new JsonResult
    //            {
    //                Data = new
    //                {
    //                    // put whatever data you want which will be sent
    //                    // to the client
    //                    Action="Session_Expire",
    //                    message = "Sorry, you were logged out, Please login again."
    //                },
    //                JsonRequestBehavior = JsonRequestBehavior.AllowGet
    //            };
    //        }
    //        else
    //        {
    //            base.HandleUnauthorizedRequest(filterContext);
    //        }
    //    }
    //}


}