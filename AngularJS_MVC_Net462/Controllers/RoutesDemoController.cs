using System.Web.Mvc;

namespace AngularJS_MVC_Net462.Controllers
{
    public class RoutesDemoController : Controller
    {
        public ActionResult One()
        {
            return View();
        }

        public ActionResult Two(int donuts = 1)
        {
            ViewBag.Donuts = donuts;
            return View();
        }

        [Authorize]
        public ActionResult Three()
        {
            return View();
        }
    }
}