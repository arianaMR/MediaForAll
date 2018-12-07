using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire.Dashboard;

namespace MediaForAll.Web
{
    public class CustomAuthorizationFilter : IDashboardAuthorizationFilter
    {

        public bool Authorize(DashboardContext context)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                return true;
            }

            return false;
        }
    }
}