using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CornerFlag.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Leagues",
                url: "Leagues/{id}/{action}",
                defaults: new { controller = "League", action = "Details" }
            );

            routes.MapRoute(
                name: "Teams",
                url: "Teams/{id}/{action}",
                defaults: new { controller = "Team", action = "Details" }
            );

            routes.MapRoute(
                name: "Players",
                url: "Players/{id}/{action}",
                defaults: new { controller = "Player", action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
