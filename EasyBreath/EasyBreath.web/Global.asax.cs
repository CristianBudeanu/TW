using EasyBreath.web.App_Start;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EasyBreath.web
{
     public class Global : HttpApplication
     {
          void Application_Start(object sender, EventArgs e)
          {
               // Code that runs on application startup
               AreaRegistration.RegisterAllAreas();
               RouteConfig.RegisterRoutes(RouteTable.Routes);
               BundleConfig.RegisterBundles(BundleTable.Bundles);
          }
     }
}