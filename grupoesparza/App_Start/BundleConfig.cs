using System.Web;
using System.Web.Optimization;

namespace grupoesparza
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
                        "~/Content/js/animsition.min.js",
                        "~/Content/js/3ts2ksMwXvKRuG480KNifJ2_JNM.js",
                        "~/Content/js/jquery.easing.min.js",
                        "~/Content/js/isotope.pkgd.min.js",
                        "~/Content/js/imagesloaded.pkgd.min.js",
                        "~/Content/js/owl.carousel.min.js",
                        "~/Content/js/jquery.mousewheel.min.js",
                        "~/Content/js/jquery.mb.YTPlayer.min.js",
                        "~/Content/js/lightgallery.min.js",
                        "~/Content/js/core.min.js",
                        "~/Content/js/theme.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            //Custom bundles for FrontEnd and Javascript.
            bundles.Add(new ScriptBundle("~/bundles/gallery").Include(
                        "~/assets/js/Gallery.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //Bundle Carreras ADMIN.
            bundles.Add(new ScriptBundle("~/bundles/carreras").Include(
                     "~/Areas/Administrator/Content/js/Carreras.js"));

            //Bundle Main _Layout - Administrator.
            bundles.Add(new ScriptBundle("~/bundles/_layoutjs").Include(
                                 "~/Areas/Administrator/Content/js/_layout.js"));

            //Bundle Main _Layout - Administrator.
            bundles.Add(new ScriptBundle("~/bundles/registro").Include(
                                 "~/Content/js/client/Registro.js"));
            #region 



            //CSS SECTION
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //
            bundles.Add(new StyleBundle("~/Content/vendor").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/rd-navbar.css",
                      "~/Content/css/animsition.min.css",
                      "~/Content/css/font-awesome.min.css",
                       "~/Content/css/lightgallery.min.css",
                      "~/Content/css/owl.carousel.min.css",
                      "~/Content/css/owl.theme.default.min.css",
                      "~/Content/css/jquery.mb.YTPlayer.min.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/css/arrows.css",
                      "~/Content/css/helper.css",
                      "~/Content/css/dark-style.css",
                      "~/Content/css/theme.css"));
            #endregion

            //Enable web optimizations. 
            BundleTable.EnableOptimizations = true;

        }
    }
}
