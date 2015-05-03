using System.Web;
using System.Web.Optimization;

namespace Officecore9x
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {

            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.min.js"));

            // jQueryUI CSS
            bundles.Add(new ScriptBundle("~/Scripts/plugins/jquery-ui/jqueryuiStyles").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.css"));

            // jQueryUI 
            bundles.Add(new StyleBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.min.js"));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/app/inspinia.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));
            // FitText
            bundles.Add(new ScriptBundle("~/plugins/fittext").Include(
                      "~/Scripts/plugins/fittext/jquery.fittext.js"));

            // jQuery plugins
            bundles.Add(new ScriptBundle("~/plugins/metsiMenu").Include(
                      "~/Scripts/plugins/metisMenu/jquery.metisMenu.js"));

            // Peity
            bundles.Add(new ScriptBundle("~/plugins/peity").Include(
                      "~/Scripts/plugins/peity/jquery.peity.min.js"));

            // Pace progress bars
            bundles.Add(new ScriptBundle("~/plugins/pace").Include(
                      "~/Scripts/plugins/pace/pace.min.js"));

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/wrapbootstrap.css"));
            //Font Awesome
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/fonts/font-awesome/css/font-awesome.min.css"));

            // Site Themes
            bundles.Add(new StyleBundle("~/themes/green").Include(
                      "~/Content/themes/Green/Green.css"));
            bundles.Add(new StyleBundle("~/themes/blue").Include(
                     "~/Content/themes/Blue/Blue.css"));
            bundles.Add(new StyleBundle("~/themes/pink").Include(
                     "~/Content/themes/Pink/Pink.css"));
            bundles.Add(new StyleBundle("~/themes/greygreen").Include(
                     "~/Content/themes/GreyGreen/GreyGreen.css"));
            bundles.Add(new StyleBundle("~/themes/gold").Include(
                     "~/Content/themes/Gold/Gold.css"));

            //Ridiculous Responsive Social Share
            bundles.Add(new ScriptBundle("~/plugins/socialshare").Include(
                      "~/Scripts/plugins/rrsociashare/rrssb.min.js"));
            bundles.Add(new StyleBundle("~/rrsociashare/css").Include(
                     "~/Content/plugins/rrsocialshare/rrssb.css"));
        }
    }
}
