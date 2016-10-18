using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoneyFlow
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "angular",
                url: "home/{*.}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "MoneyFlow.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "MoneyFlow.Controllers" }
            );

            //routes.MapRoute(
            //    name: "spa-fallback",
            //    url: "{*url}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);

            //routes.MapRoute(
            //    "angular-spa-callback",
            //    "{*url}",
            //    new { controller = "Home", action = "Index" }
            //);
        }
    }
}
