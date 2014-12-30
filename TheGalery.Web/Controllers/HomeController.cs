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
            var manager = new ImageManager(UserCredentials.Default);
            List<ImageGroup> images = manager.GetAllImages().Result;
            var imageGroupViewList = new List<ImageGroupViewModel>();
            foreach (ImageGroup imageGroup in images)
            {
                string name = imageGroup.Name;
                string path = Server.MapPath(Path.Combine("Images", name));
                var groupViewRow = new ImageGroupViewModel(name, path);
                imageGroupViewList.Add(groupViewRow);
            }

            return View(new HomeViewModel(imageGroupViewList));
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

        public ActionResult Thumbnail(string name)
        {
            var imageManager = new ImageManager(UserCredentials.Default);
            ImageGroup imageGroup = imageManager.GetImages(name).Result;
            string path = Server.MapPath(string.Format("~/Images/{0}", name));
            return PartialView(new ImageGroupViewModel(imageGroup.Name, path));
        }

        public ActionResult Images(string name)
        {
            var imageManager = new ImageManager(UserCredentials.Default);
            ImageGroup imageGroup = imageManager.GetImages(name).Result;
            string path = Server.MapPath(string.Format("~/Images/{0}", name));
            return View(new ImageGroupViewModel(imageGroup.Name, path));
        }

        public ActionResult Image(string name, string path)
        {
            return PartialView(new ImageViewRow(name, path));
        }
    }
}