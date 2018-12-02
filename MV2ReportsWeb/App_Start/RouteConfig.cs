using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MV2ReportsWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "auth", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Registration",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "auth", action = "Registration", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MyReports",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyReports", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Scheduler",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Schedulers", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
