using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Empty",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { action ="Index|Contact|About|GenError"}
            );            

            routes.MapRoute(
                name: "Inventory_Index",
                url: "Inventory/{action}",
                defaults: new { controller = "Inventory", action = "Index", id = UrlParameter.Optional },
                constraints: new {action = "Index"}
            );

            routes.MapRoute(
                name:"Error",
                url:"Error/{action}",
                defaults: new { controller="Error", action="Index"},
                constraints: new { action="NotFound|Index|ServerError" }

            );

            routes.MapRoute(
                name: "Account",
                url: "Account/{action}",
                defaults: new { controller = "Account", action = "Login" },
                constraints: new { action = "Login|Logout" }

            );

            routes.MapRoute(
                "NotFound",
                "{*url}",
                defaults: new { controller = "Error", action = "NotFound" }
                );
        }
    }
}
