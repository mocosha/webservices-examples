using System.Web;
using System.Web.Mvc;

namespace Mocosha.WebApi.SimpleStorage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
