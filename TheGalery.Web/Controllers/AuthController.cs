using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ClientServices;
using System.Web.Mvc;
using System.Web.Security;
using Antlr.Runtime.Misc;
using Microsoft.Live;

namespace TheGalery.Web.Controllers
{
    public class AuthController : Controller
    {
        private static readonly string[] scopes =
        {
            "wl.signin",
            "wl.basic",
            "wl.calendars"
        };

        private const string RedirectUri = "http://yaeldayanphoto.azurewebsites.net/Auth/Redirect";

        private readonly LiveAuthClient authClient = new LiveAuthClient(
            "000000004C13618D",
            "vLh6wkDP-RlUFvIM48q46YO-r4H26wyY",
            RedirectUri);

        public async Task<ActionResult> Index(string returnUrl)
        {
            LiveLoginResult loginStatus = await authClient.InitializeWebSessionAsync(HttpContext);
            switch (loginStatus.Status)
            {
                case LiveConnectSessionStatus.Expired:
                case LiveConnectSessionStatus.Unknown:
                    var dictionary = new Dictionary<string, string>();
                    dictionary["state"] = returnUrl;
                    string reAuthUrl = authClient.GetLoginUrl(scopes, dictionary);
                    return new RedirectResult(reAuthUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Redirect()
        {
            var result = await authClient.ExchangeAuthCodeAsync(HttpContext);
            if (result.Status == LiveConnectSessionStatus.Connected)
            {
                var client = new LiveConnectClient(authClient.Session);
                AuthManager.Instance.Client = client;

                LiveOperationResult meResult = await client.GetAsync("me");
                string userName = meResult.Result["name"].ToString();

                CreateAuthTicket(userName);

                string returnUrl = result.State;

                this.Response.Redirect(returnUrl);
                return null;
            }

            return HttpNotFound();
        }

        public ActionResult Logout()
        {
            authClient.ClearSession(this.HttpContext);
            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);

            string home = Url.Action("Index", "Home");
            Response.Redirect(home);
            return null;
        }

        private void CreateAuthTicket(string userName)
        {
            var authTicket = new FormsAuthenticationTicket(
                2,
                userName,
                DateTime.Now,
                DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                false,
                "Token that will be used to access the web service and that you have fetched"
                );
            var authCookie = new HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(authTicket)
                )
            {
                HttpOnly = true
            };
            Response.AppendCookie(authCookie);

        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            if (httpContext.Request.Cookies == null ||
                httpContext.Request.Cookies[cookieName] == null)
            {
                return false;
            }

            var authCookie = httpContext.Request.Cookies[cookieName];
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            IPrincipal userPrincipal = new MyPrincipal(authTicket.Name);

            // Inject the custom principal in the HttpContext
            httpContext.User = userPrincipal;
            return true;
        }
    }
    public class MyPrincipal : IPrincipal
    {
        public MyPrincipal(string userName)
        {
            Identity = new MyIdentity(userName);

        }

        public bool IsInRole(string role)
        {

            return true;
        }

        public IIdentity Identity { get; private set; }
    }

    public class MyIdentity : IIdentity
    {
        public MyIdentity(string name)
        {
            Name = name;
            IsAuthenticated = true;

        }

        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }

        public bool IsAuthenticated { get; private set; }
    }
}