using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Diagnostics.Contracts;
using OneTeamAptitudeMVC.Scripts;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Web.Security;
using AutoMapper;

namespace OneTeamAptitudeMVC.Web.Filters
{
    public class AptitudeAuthorizeAttributes : AuthorizeAttribute
    {
        //private static bool SkipAuthorization(AuthorizationContext filterContext)
        //{
        //    Contract.Assert(filterContext != null);

        //    return filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any()
        //           || filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
        //}

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (SkipAuthorization(filterContext)) return;
            if (SessionManager.UserID == null)
            {
                /*
                 *  This Code is preventinting Login Page shown in bootbox dialogue
                 *  Global ajaxSetup will catch the aborted jqXHR in error callback 
                 *  and check the status === 0 , 0 -> means aborted request
                 *  if status is 0 change window.location to login Page
                 * */
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Request.Abort();
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Account",
                                action = "Login"//"Login"LogOff
                            }));
                }
            }
            else
            {
               User authenticatedUser = SessionManager.AuthenticatedUser;
                AptitudePrincipal pricipal = new AptitudePrincipal(authenticatedUser);

                if (!pricipal.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccesDenied", action = "Index" }));
                }
            }
        }
    }
}