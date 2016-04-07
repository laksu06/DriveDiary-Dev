//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System.Web;
using System.Web.Optimization;

namespace DriveDiaryWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.decimal-fixvalidation.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // SL: Add chart.js
            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                      "~/Scripts/chart.js"));

            // SL: Add Bootstrap datetimepicker to script bundles - layout part of view
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker-layout").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/jquery-ui-{version}.js",
                      "~/Scripts/globalize.js",
                      "~/Scripts/bootstrap.js"));

            // SL: Add Bootstrap datetimepicker to script bundles - index part of view
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker-index").Include(
                      "~/Scripts/moment-with-locales.js",
                      "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css-datetimepicker-layout").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/css-datetimepicker-index").Include(
                      "~/Content/bootstrap-datetimepicker.css"));

        }
    }
}
