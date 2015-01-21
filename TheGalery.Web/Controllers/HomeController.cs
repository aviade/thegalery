using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Live;
using TheGalery.Web.Models;

namespace TheGalery.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [MyAuthorize]
        public async Task<ActionResult> Manage()
        {
            var viewModel = new ManageViewModel();
            LiveConnectSession session = (LiveConnectSession)Session[Constants.LiveSdkSessionKey];
            var client = new LiveConnectClient(session);
            LiveOperationResult meResult = await client.GetAsync("me");
            LiveOperationResult mePicResult = await client.GetAsync("me/picture");
            LiveOperationResult calendarResult = await client.GetAsync("me/calendars");

            string userName = meResult.Result["name"].ToString();
            viewModel.UserName = userName;
            viewModel.PhotoLocation = mePicResult.Result["location"].ToString();
            viewModel.CalendarJson = calendarResult.RawResult;

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