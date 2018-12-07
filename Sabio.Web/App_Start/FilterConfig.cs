using MediaForAll.Web.Classes;
using System.Web;
using System.Web.Mvc;
// ********** FYI: System Generated File

namespace MediaForAll.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            if (SiteConfig.Environment != "WINHOST")
            {
                filters.Add(new RequireHttpsAttribute());

            }
        }
    }
}
