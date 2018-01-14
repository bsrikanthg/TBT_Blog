using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TBT_Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        { 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.asmx/{*pathInfo}");

            routes.MapRoute(
                name: "Serial",
                url: "Serial",
                defaults: new { controller = "Home", action = "Serial" }
                );
            routes.MapRoute(
                 name: "Posts",
                 url: "Posts/{PostName}",
                 defaults: new { controller = "Home", action = "Index", PostName = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{PostName}",
                defaults: new { controller = "Home", action = "Index", PostName = UrlParameter.Optional }
            );

        }
    }
}
