using System.Web.Mvc;

namespace AspNet_4x_BasicAuthHttp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new AuthorizeAttribute());
        }
    }
}
