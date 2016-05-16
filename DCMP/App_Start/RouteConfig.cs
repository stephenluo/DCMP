using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DCMP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            MvcHelper helper = MvcHelper.Create("DCMP.Controllers");
            //用户信息接口路径
            helper.MapRoute("api/MonitoringOverview/", "Monitoring", "MonitoringOverview");
            
        }
    }
}
