﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MVCFormsAuthentication
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                FormsAuthentication.SignOut();
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account/AccessDenied" }));
               
            }
        }
    }
}