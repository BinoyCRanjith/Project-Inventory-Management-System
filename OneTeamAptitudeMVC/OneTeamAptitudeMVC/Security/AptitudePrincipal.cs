using OneTeamAptitudeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace OneTeamAptitudeMVC.Web.Security
{
    public class AptitudePrincipal : IAppsTeamPrincipal
    {
        private User _user;
      

        public AptitudePrincipal(User user)
        {
            _user = user;
            if (_user != null)
            {
                this.Identity = new GenericIdentity(this._user.Name);
            }
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ','});
            return roles.Any(r => this._user.RollName.Contains(r));
        }
    }
}