using System.Web;
using System.Web.Mvc;

namespace Epiphany_Music_App_1._0.WEBMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
