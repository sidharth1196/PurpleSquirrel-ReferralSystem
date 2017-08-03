using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReferralSystem.Data;
using ReferralSystem.Services;
using ReferralSystem.ServiceContracts;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;


namespace ReferralSystem.Framework.Security
{
    public class ReferralSystemPrincipal : IPrincipal
    {
        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <value>The identity.</value>
        public IIdentity Identity { get; private set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int? UserID { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int? EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the type of the role.
        /// </summary>
        /// <value>
        /// The type of the role.
        /// </value>
        public string RoleType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Principal"/> class.
        /// </summary>
        public ReferralSystemPrincipal(string username,FormsAuthenticationTicket authTicket)
        {
            this.Username = username;
            UserAuthService userAuthService = DependencyResolver.Current.GetService<UserAuthService>();
            
            UserViewModel user = userAuthService.GetUser(username);
            this.Identity = new FormsIdentity(authTicket);
            this.UserID = user.UserID;
            this.EmployeeID = user.EmployeeID;
            this.RoleType = user.Type;


        }

        public bool IsInRole(string role)
        {
            if(RoleType==role)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}