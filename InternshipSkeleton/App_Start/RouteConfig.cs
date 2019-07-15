using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AsignioInternship
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
            
            //adding a new route to use for searching and sorting data 
            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/{searchBy}/{searchInput}/{sortBy}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional, searchBy = "", searchInput="", sortBy = "TimeStamp" }
            ); 
        }
	}
}
