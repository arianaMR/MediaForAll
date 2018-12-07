using System.Web;
using System.Web.Optimization;

namespace MediaForAll.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //  Sabio application
            //  ------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/sabio/base").Include(
                      "~/Scripts/sabio.js"));


            //  Sabio application
            //  ------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/sabio/core").Include(

                      "~/Scripts/sabio/sabio.module.js",
                      "~/Scripts/sabio/core/controllers/*.js",
                      "~/Scripts/sabio/core/services/*.js"));

            //  v2.0 / Bower versions
            //  ------------------------------------------------------------
            bundles.Add(new StyleBundle("~/bower/bootstrap/css").Include(
                      "~/Scripts/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Scripts/bower_components/ngAnimate/css/ng-animation.css",
                      "~/Scripts/bower_components/angular-toastr/dist/angular-toastr.css"));

            bundles.Add(new StyleBundle("~/site/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bower/bootstrap/js").Include(
                      "~/Scripts/bower_components/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bower/jquery").Include(
                      "~/Scripts/bower_components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bower/angular").Include(
                      "~/Scripts/bower_components/angular/angular.js",
                      "~/Scripts/bower_components/angular-animate/angular-animate.js",
                      "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap.js",
                      "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap-tpls.js",
                      "~/Scripts/bower_components/angular-route/angular-route.js",
                      "~/Scripts/bower_components/angular-toastr/dist/angular-toastr.js",
                      "~/Scripts/bower_components/angular-toastr/dist/angular-toastr.tpls.js"
                      ));

            bundles.Add(new ScriptBundle("~/bower/angular/angular-translate").Include(                
                 "~/Scripts/bower_components/angular-translate/angular-translate.js"
                ,"~/Scripts/bower_components/angular-translate/angular-translate-extensions//angular-translate-handler-log.js"    
                /*uncomment one of the next three files corresponding to your choice for the translation loader service; that choice is made in the angular-translate-services-configuration file.
                 ,"~/Scripts/bower_components/angular-translate/angular-translate-extensions/angular-translate-loader-static-files.js"  
                 ,"~/Scripts/bower_components/angular-translate/angular-translate-extensions/angular-translate-loader-url.js"*/
                 , "~/Scripts/bower_components/angular-translate/angular-translate-extensions/angular-translate-loader-partial.js"
                /* these next two files implement angular-translate's preferred pluralization extension. If you choose to implement this in the translate-services-configuration file, uncomment these
                , "~/Scripts/bower_components/angular-translate/angular-translate-extensions/angular-translate-interpolation-messageformat.js"
                , "~/Scripts/bower_components/angular-translate/angular-translate-extensions/messageformat.js" pluralization, not yet implemented */
                , "~/Scripts/ng/angular-cookies.js"
                , "~/Scripts/bower_components/angular-translate/angular-translate-extensions/angular-translate-storage-cookie.js"
                , "~/Scripts/bower_components/angular-translate/angular-translate-extensions/angular-translate-storage-local.js"
                , "~/Scripts/i18n/angular-translate-services-configurations.js"
                , "~/Scripts/i18n/view-localizations/shared/shared-localization-loader.js"
                , "~/Scripts/i18n/view-localizations/shared/shared-localization-controller.js"
                ));


            //Sabio: this disables the optimizations in Bundles. 
            //this allows all files  to be rendered separately while we develop
            BundleTable.EnableOptimizations = false;
        }
    }
}
