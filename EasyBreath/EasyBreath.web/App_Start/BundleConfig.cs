using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EasyBreath.web.App_Start
{
     public class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                              "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
               
               bundles.Add(new StyleBundle("~/bundles/bootstrap/js").Include(
                              "~/Scripts/bootstrap.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                           "~/Scripts/jquery-{version}.js"));

               bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                           "~/Scripts/jquery.validate*"));
          }
     }
}