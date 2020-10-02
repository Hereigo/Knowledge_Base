using System.Web;
using System.Web.Mvc;

namespace AngularJS_ASPnet48_XML
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
