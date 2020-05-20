﻿using System.Web.Optimization;

namespace AngularJS_ASPNet_MVC_4
{
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/AngularMVCAppBundle")
                        .IncludeDirectory("~/App_NG/Controllers", "*.js")
                        .Include("~/App_NG/AppNgMainModule.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
