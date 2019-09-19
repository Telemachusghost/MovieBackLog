using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace MovieBackLogFramework.Models
{
    public class CurrentUser
    {
        public CurrentUser(IIdentity identity)
        {
            IsAuthenticated = identity.IsAuthenticated;
            DisplayName = identity.Name;

            var formsIdentity = identity as FormsIdentity;

            if (formsIdentity != null)
            {
                UserID = int.Parse(formsIdentity.Ticket.UserData);
            }
        }

        // TODO: Testing constructor
        public CurrentUser()
        {

        }

        public string DisplayName { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public int UserID { get; private set; }
    }
}