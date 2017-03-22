using System.Web;
using System.Web.Optimization;

namespace TuneMax
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                        "~/-Slider/slider.js", "~/-Slider/script.js"));

            bundles.Add(new ScriptBundle("~/-HtmlEditor/ckeditor.js").Include(
                        "~/-HtmlEditor/ckeditor.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/main").Include("~/Content/Public.css"));
            bundles.Add(new StyleBundle("~/Content/account").Include("~/Content/Private.css"));
            bundles.Add(new StyleBundle("~/Content/slider").Include("~/Content/slider/style.css"));

            bundles.Add(new StyleBundle("~/Content/themes").Include(
                        "~/Content/themes/THEME/jquery-ui-1.10.3.css"));
        }
    }
}