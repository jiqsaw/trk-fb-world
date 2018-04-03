using System.Web;
using System.Web.Optimization;

namespace TurkcellFacebookDunyasi.Admin
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.7.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunobt").Include(
                        "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));




            //SCRIPTS

            bundles.Add(new ScriptBundle("~/Scripts/app/").Include(
                "~/Scripts/app/jquery/plugins/colorbox/jquery.colorbox.js",
                "~/Scripts/app/jquery/plugins/utils.js",
                "~/Scripts/app/utils.js",
                "~/Scripts/app/global.js",
                "~/Scripts/app/jquery/globalize/jQuery.globalize.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/kendo/").Include(
                "~/Scripts/kendo/kendo.web.js",
                "~/Scripts/kendo/kendo.aspnetmvc.js",
                "~/Scripts/app/kendoManager.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/init").Include(
                "~/Scripts/app/init.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/render").Include(
                "~/Scripts/app/globalization.js",
                "~/Scripts/app/render.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/login").Include(
                "~/Scripts/app/login.js"
            ));




            //STYLES

            bundles.Add(new StyleBundle("~/Content/kendo").Include(

                "~/Content/kendo/kendo.common.css",
                "~/Content/kendo/kendo.default.css"
            ));

            bundles.Add(new StyleBundle("~/Styles/").Include(

                "~/Styles/utils/reset.css",
                "~/Styles/utils/common.css",

                "~/Styles/layout.css",
                "~/Styles/global.css",
                "~/Styles/form.css",
                "~/Styles/screen.css",

                "~/Styles/kendo.css",

                "~/Styles/print.css"
            ));

            bundles.Add(new StyleBundle("~/Plugin").Include(

                "~/Scripts/app/jquery/plugins/colorbox/colorbox.css"
            ));

            bundles.Add(new StyleBundle("~/Styles/login").Include(

                "~/Styles/login.css"
            ));

        }
    }
}