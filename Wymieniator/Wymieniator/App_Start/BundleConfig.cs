using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Wymieniator.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryAndjqueryUIAndFilesForWebsite").Include(
                                        "~/Scripts/jquery-{version}.js",
                                        "~/Scripts/jquery-ui-{version}.js",
                                        "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                                        "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                                        "~/Scripts/js/sb-admin.min.js"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                                        "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                                        "~/Content/vendor/fontawesome-free/css/all.min.css",
                                        "~/Content/vendor/datatables/dataTables.bootstrap4.css",
                                        "~/Content/css/sb-admin.css"));
        }
    }
}