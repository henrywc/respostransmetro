using System.Web.Mvc;

namespace BlackSys
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection Filters)
        {
            Filters.Add(new HandleErrorAttribute());
        }
    }
}