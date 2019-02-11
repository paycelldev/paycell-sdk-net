using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace paycell_web_sdk_client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Welcome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CheckStatus",
                url: "{controller}/{action}/{paymentReferenceNumber}",
                defaults: new { controller = "Home", action = "CheckStatus", paymentReferenceNumber = UrlParameter.Optional }
            );
        }
    }
}
