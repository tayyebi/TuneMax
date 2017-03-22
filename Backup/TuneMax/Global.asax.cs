using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TuneMax
{
    // Powered by Mohammad Reza Tayyebi
    // email:tayyebimohammadreza@gmail.com

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            if (!File.Exists(Server.MapPath("Dollar.xml")))
            {
                string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?><Dollar />" };
                File.WriteAllLines(Server.MapPath("~/Dollar.xml"),lines);
            }

            if (!File.Exists(Server.MapPath("CopyRight.txt")))
            {
                string[] lines = { "Powered by Mohammad Reza Tayyebi", "Email:tayyebimohammadreza@gmail.com" };
                File.WriteAllLines(Server.MapPath("~/CopyRight.txt"), lines);
            }

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            Response.Redirect("~/Home/AppError");
        }
    }
}