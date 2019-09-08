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
                name: "Default",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
             name: "Posts",
             url: "Posts/{OperatingSystem}/{Category}/{PostName}",
             defaults: new
             {
                 controller = "Post",
                 action = "Index",
                 OperatingSystem = UrlParameter.Optional,
                 Category = UrlParameter.Optional,
                 PostName = UrlParameter.Optional
             }
         );



        }
    }
}
