﻿using System.Web;
using System.Web.Optimization;

namespace TBT_Blog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/JSlib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.unob*",
                        "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/datatables/datatables.bootstrap.js"));

            //bundles.Add(new ScriptBundle("~/bundles/GoogleAnalytics", "https://www.googletagmanager.com/gtag/js?id=UA-102028776-1")
            //    .Include("~/Scripts/GoogleAnalyticsScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery - ui.css",
                      "~/Content/Bootstrap_Custom.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/site.css",
                        "~/Content/Typeahead.css"));
        }
    }
}
