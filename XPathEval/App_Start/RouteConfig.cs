using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace XPathEval
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Demo",
                url: "{id}/{rev}",
                defaults: new { controller = "XPath", action = "Index", rev = UrlParameter.Optional },
                constraints: new { id = @"^[a-zA-Z0-9_\-]+$", rev = @"\d*" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{rev}",
                defaults: new { controller = "XPath", action = "Index", id = UrlParameter.Optional, rev = UrlParameter.Optional }
            );
            
        }
    }
}
