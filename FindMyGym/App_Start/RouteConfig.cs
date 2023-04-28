using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FindMyGym
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { action = @"^[a-zA-Z]+$" }
            );

            // Ruta personalizada para eliminar la extensión .cshtml
            routes.MapRoute(
                "CatchAll",
                "{*url}",
                new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Inicio",
                url: "Inicio",
                defaults: new { controller = "Home", action = "Index" }
);
            routes.MapRoute(
                name: "Acceso",
                url: "Acceso/Login",
                defaults: new { controller = "Acceso", action = "Login" }
);
        }

    }
}
