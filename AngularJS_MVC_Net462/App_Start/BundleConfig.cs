using System.Web.Optimization;

namespace AngularJS_MVC_Net462
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/AwesomeAngularMVCApp")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/Factories", "*.js")
                .Include("~/Scripts/AwesomeAngularMVCApp.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
