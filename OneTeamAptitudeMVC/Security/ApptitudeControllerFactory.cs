using AutoMapper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Scripts;
using OneTeamAptitudeMVC.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OneTeamAptitudeMVC.Web.security
{
    public class ApptitudeControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            #region Getting User Information
            User authenticatedUser = null;
            if (SessionManager.AuthenticatedUser != null)
            {
                authenticatedUser = SessionManager.AuthenticatedUser;
            }

            HttpContext.Current.User = Thread.CurrentPrincipal = new AptitudePrincipal(authenticatedUser); 
            #endregion

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}