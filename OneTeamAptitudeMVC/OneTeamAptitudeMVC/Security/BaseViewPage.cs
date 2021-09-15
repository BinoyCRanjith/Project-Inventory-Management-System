using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Web.Security
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new IAppsTeamPrincipal User
        {
            get
            {
                return (IAppsTeamPrincipal)base.User;
            }
        }
    }
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new IAppsTeamPrincipal User
        {
            get
            {
                return (IAppsTeamPrincipal)base.User;
            }
        }

    }
}