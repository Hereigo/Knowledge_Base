using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AngularJS_ASPnet48_XML.DataAccess;
using AngularJS_ASPnet48_XML.Helpers;
using AngularJS_ASPnet48_XML.Models;

namespace AngularJS_ASPnet48_XML.Controllers
{
    public class HomeController : Controller
    {
        private readonly DetailsData detailsData = new DetailsData();
        private readonly ProductsData productsData = new ProductsData();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList()
        {
            Product[] products = productsData.GetAll().ToArray();

            // Remove html-codes from model description.
            // not using in the current time.
            Product[] productsVM = products.Select(item => new Product()
            {
                Description = CustomHtmlHelpers.RemoveHTMLTags(item.Description),
                Id = item.Id,
                Image = item.Image,
                Popular = item.Popular,
                Price = item.Price,
                Title = item.Title
            }
            ).ToArray();

            return Json(products);
        }

        public JsonResult GetAvailability()
        {
            var avalabilities = detailsData.GetAvailabilities();
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(avalabilities);

            // Just to demonstarate the Ajax work.
            System.Threading.Thread.Sleep(1500);

            return Json(serializedResult);
        }

        public ActionResult Details(string id)
        {
            List<Detail> details = detailsData.GetAll().ToList();

            List<Product> products = productsData.GetAll().ToList();

            DetailsVM detailsVM = (from detail in details
                                   join product in products
                                   on detail.Id equals product.Id
                                   where detail.Id == id
                                   select new DetailsVM()
                                   {
                                       Description = detail.Description,
                                       Id = detail.Id,
                                       Image = detail.Image,
                                       Price = product.Price,
                                       Specs = detail.Specs,
                                       Title = detail.Title
                                   }).First();


            return View(detailsVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}