using Microsoft.Live;

namespace TheGalery.Web.Controllers
{
    public class AuthManager
    {
        static readonly AuthManager instance = new AuthManager();

        public static AuthManager Instance
        {
            get { return instance; }
        }

        public LiveConnectClient Client { get; set; }
    }
}