using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Live;
using TheGalery.Core;
using TheGalery.Core.Readers;
using TheGalery.Web.Models;

namespace TheGalery.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [LiveSdkAuthorize]
        public async Task<ActionResult> Manage()
        {
            var viewModel = new ManageViewModel();
            var session = (LiveConnectSession)Session[Constants.LiveSdkSessionKey];
            var client = new LiveConnectClient(session);
            LiveOperationResult meResult = await client.GetAsync("me");
            LiveOperationResult mePicResult = await client.GetAsync("me/picture");

            string userName = meResult.Result["name"].ToString();
            viewModel.UserName = userName;
            viewModel.PhotoLocation = mePicResult.Result["location"].ToString();

            var oneDriveReader = new OneDriveReader(client);
            ImageLibrary imageLibrary = await oneDriveReader.GetFolders();

            return View(viewModel);
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