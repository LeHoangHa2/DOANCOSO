using System.Web;
using System.Web.Optimization;

namespace Website_Library
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/CustomJS").Include(
                     "~/Content/js/jquery.easing.1.3.js",
                     "~/Content/plugins/flexslider/jquery.flexslider.js",
                     "~/Content/plugins/flexslider/flexslider.config.js",
                     "~/Content/js/jquery.appear.js",
                     "~/Content/js/stellar.js",
                     "~/Content/js/classie.js",
                     "~/Content/js/uisearch.js",
                     "~/Content/js/jquery.cubeportfolio.js",
                     "~/Content/js/google-code-prettify/prettify.js",
                     "~/Content/js/animate.js",
                     "~/Content/js/custom.js"

                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/plugins/flexslider/flexslider.css",
                      "~/Content/css/cubeportfolio.css",
                      "~/Content/css/style.css",
                      "~/Content/bodybg/bg1.css"));
        }
    }
}
