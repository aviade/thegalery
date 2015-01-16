using System.Web.Mvc;

namespace TheGalery.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HeaderImagePath = "/fonts/Gallery-Header.png";
            return View();
            return RedirectToAction("Index", "Gallery");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}