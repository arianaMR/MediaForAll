using Hangfire;
using MediaForAll.Web.Background.Internal;
using MediaForAll.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MediaForAll.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //  enable Unity injection - based on example from http://www.asp.net/web-api/overview/advanced/dependency-injection
            UnityConfig.RegisterComponents(System.Web.Http.GlobalConfiguration.Configuration);

            // Only start hangfire for specfic environments where
            // you want it to run - should eventually allow
            // where environment is "PROD"
            if (SiteConfig.Environment == "blah")
            {
                HangfireBootstrapper.Instance.Start();

                // BackgroundJob.Enqueue(() => System.Diagnostics.Debug.WriteLine("Hangfire instance started"));
                //RecurringJob.AddOrUpdate(() => Sabio.Web.Services.MlsService.BatchListingsUpsert("total", "recent"), Cron.Daily);
                //RecurringJob.AddOrUpdate(() => Sabio.Web.Services.MlsService.BatchMediaUpsert("total", "recent"), Cron.Daily);
                // RecurringJob.AddOrUpdate<UserEventFeedTask>("EventFeed", task => task.Run(null, JobCancellationToken.Null), Cron.Daily);
                // RecurringJob.AddOrUpdate<PopulateESTask>("PopulateES", task => task.Run(null, JobCancellationToken.Null), Cron.HourInterval(1));
            }

        }
        protected void Application_End(object sender, EventArgs e)
        {
            HangfireBootstrapper.Instance.Stop();
        }
    }
}
