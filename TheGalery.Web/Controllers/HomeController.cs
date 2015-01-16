using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheGalery.Core;
using TheGalery.Web.Models;

namespace TheGalery.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HeaderImagePath = "/fonts/Yael.png";
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