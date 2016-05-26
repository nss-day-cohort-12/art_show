using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace art_gallery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UpcomingEvents",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UpcomingEvents", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Owner",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Owner", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Agents",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Agents", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
