using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web;
using System.Web.Optimization;



namespace OneTeamAptitudeMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            var nullBuilder = new NullBuilder();
            var styleTransformer = new StyleTransformer();
            var scriptTransformer = new ScriptTransformer();
            var nullOrderer = new NullOrderer();
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css"));

            //bundles.Add(new ScriptBundle(("~/bundles/customBundle").inc
            //    .Include("~assets/js/canvasjs.min.js");
            //var canvasJsbundle = new Bundle("~assets/js/canvasjs.min.js");
            //canvasJsbundle.Builder = nullBuilder;
            //canvasJsbundle.Transforms.Add(styleTransformer);
            //canvasJsbundle.Orderer = nullOrderer;
            //bundles.Add(canvasJsbundle);

            var datatableStylesBundle = new Bundle("~/css/datatable");
            datatableStylesBundle.Include("~/assets/js/datatable-1.10.12/media/css/dataTables.bootstrap.min.css");
            datatableStylesBundle.Include("~/assets/js/datatable-1.10.12/extensions/Responsive/css/responsive.dataTables.min.css");
            datatableStylesBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/css/buttons.dataTables.min.css");
            datatableStylesBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/css/buttons.bootstrap.min.css");

            datatableStylesBundle.Builder = nullBuilder;
            datatableStylesBundle.Transforms.Add(styleTransformer);
            datatableStylesBundle.Orderer = nullOrderer;
            bundles.Add(datatableStylesBundle);

            var dataTableBundle = new Bundle("~/bundles/datatable");
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/media/js/jquery.dataTables.min.js");
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/media/js/dataTables.bootstrap.min.js");
            //Extensions
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Responsive/js/dataTables.responsive.min.js");
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/js/dataTables.buttons.min.js");
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/js/buttons.flash.min.js");
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/js/buttons.print.min.js");
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/js/jszip.min.js");    //for excel export
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/js/pdfmake.min.js");// for pdf Export
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/js/vfs_fonts.js");// for pdf Export
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/extensions/Buttons/js/buttons.html5.min.js");

            //Basic Configurations
            dataTableBundle.Include("~/assets/js/datatable-1.10.12/datatables-init.js");

            dataTableBundle.Builder = nullBuilder;
            dataTableBundle.Transforms.Add(scriptTransformer);
            dataTableBundle.Orderer = nullOrderer;
            bundles.Add(dataTableBundle);



        }
    }
}
