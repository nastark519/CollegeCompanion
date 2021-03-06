﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace collegeCompanionApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Search",
                url: "Home/{action}/{page}",
                defaults: new { controller = "Home", action = "Search", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DemographicSearch",
                url: "Home/{action}/{page}",
                defaults: new { controller = "Home", action = "DemographicSearch", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "YelpSearch",
                url: "Home/{action}/{page}",
                defaults: new { controller = "Home", action = "YelpSearch", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "WalkScoreSearch",
                url: "Home/{action}/{page}",
                defaults: new { controller = "Home", action = "WalkScoreSearch", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SearchResults",
                url: "Home/{action}/{page}",
                defaults: new { controller = "Home", action = "SearchResults", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
