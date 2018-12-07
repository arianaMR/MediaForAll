using Microsoft.Owin;
using Owin;
using Hangfire;
using MediaForAll.Web.Classes;

[assembly: OwinStartupAttribute(typeof(MediaForAll.Web.Startup))]
namespace MediaForAll.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var options = new DashboardOptions
            {
                Authorization = new[] { new CustomAuthorizationFilter() }
            };

            // Only start hangfire for specfic environments where
            // you want it to run - should eventually allow
            // where environment is "PROD"
            if (SiteConfig.Environment == "blah")
            {
                app.UseHangfireDashboard("/hangfire", options);
            }
        }
    }
}
