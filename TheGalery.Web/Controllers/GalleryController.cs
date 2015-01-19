using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheGalery.Core;
using TheGalery.Web.Models;

namespace TheGalery.Web.Controllers
{
    public class GalleryController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HeaderImagePath = "/fonts/Yael.png";

            var manager = GetImageManager();
            List<ImageGroup> images = manager.GetAllImages().Result;

            var imageGroupViewList = new List<ImageGroupViewModel>();
            foreach (ImageGroup imageGroup in images)
            {
                string groupNane = imageGroup.Name;
                ImageGroupViewModel groupViewRow = GetImageGroupViewModel(groupNane);
                imageGroupViewList.Add(groupViewRow);
            }

            ImageGroupViewModel rootImageGroup = GetImageGroupViewModel(string.Empty); 
            return View(new GaleryViewModel(rootImageGroup, imageGroupViewList));
        }

        private static ImageManager GetImageManager()
        {
            var manager = new ImageManager(UserCredentials.Default);
            return manager;
        }

        private ImageGroupViewModel GetImageGroupViewModel(string name)
        {
            var groupViewRow = new ImageGroupViewModel(name);
            string folderPath = Path.Combine("~/Images", name);
            string path = Server.MapPath(folderPath);
            var directoryInfo = new DirectoryInfo(path);
            var files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                string fileName = file.Name;
                if (!string.IsNullOrEmpty(name))
                {
                    name = "/" + name;
                }
                string relativePath = string.Format("/Images{0}/{1}", name, fileName);
                groupViewRow.Add(new ImageViewRow(fileName, file.FullName,
                    ImageSize.Small, relativePath));
            }
            return groupViewRow;
        }

        public ActionResult Thumbnail(string name)
        {
            var manager = GetImageManager();
            ImageGroup imageGroup = manager.GetImages(name).Result;
            var imageGroupViewModel = GetImageGroupViewModel(imageGroup.Name);
            return PartialView(imageGroupViewModel);
        }

        public ActionResult Images(string name)
        {
            ViewBag.HeaderImagePath = "/fonts/Yael.png";
            var manager = GetImageManager();
            ImageGroup imageGroup = manager.GetImages(name).Result;
            var imageGroupViewModel = GetImageGroupViewModel(imageGroup.Name);
            return View(imageGroupViewModel);
        }

        public ActionResult Image(string name, string path, ImageSize imageSize)
        {
            return PartialView(new ImageViewRow(name, path, imageSize, ""));
        }
        public ActionResult Photo(string name, string path, string groupName)
        {
            ViewBag.HeaderImagePath = "/fonts/Yael.png";
            return View(new PhotoViewRow(name, path, ImageSize.Large, groupName, ""));
        }
    }
}