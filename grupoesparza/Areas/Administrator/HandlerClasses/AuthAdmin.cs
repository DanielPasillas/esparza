﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace grupoesparza.Areas.Administrator.HandlerClasses
{
    public class AuthAdmin : AuthorizeAttribute
    {
        //This file is used to redirect to the Administrator Area log-in.
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string controller = filterContext.RouteData.Values["controller"].ToString();
            filterContext.Result = new RedirectToRouteResult(new 
            RouteValueDictionary(new { controller = "admon", action = "admin-login" }));
        }
    }
}