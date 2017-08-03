using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReferralSystem.Filters
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ReferralSystemAuthorize : AuthorizeAttribute
    {
        /// <summary>
        /// The allowedroles
        /// </summary>
        private string AllowedRole;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProactAuthorize"/> class.
        /// </summary>
        public ReferralSystemAuthorize(string Role)
        {
            this.AllowedRole = Role;
        }

        /// <summary>
        /// Called when a process requests authorization.
        /// </summary>
        /// <param name="filterContext">The filter context, which encapsulates information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute" />.</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if(!skipAuthorization)
                base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>true if the user is authorized; otherwise, false.</returns>

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            if(httpContext.User.Identity.IsAuthenticated)
            {
                if(httpContext.User.IsInRole(AllowedRole))
                    {
                        
                    authorize = true;
                    }
            }

            return authorize; 
        }
    }
}