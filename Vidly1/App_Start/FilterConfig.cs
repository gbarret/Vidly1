using System.Web;
using System.Web.Mvc;

namespace Vidly1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // 20190515 Restricting access to all the pages ...
            filters.Add(new AuthorizeAttribute());
            // 20190529 Adding Https. Otherwise the pages can be accessed using just http ...
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
