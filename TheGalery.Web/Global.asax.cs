using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TheGalery.Web.Controllers;

namespace TheGalery.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            bool isAuthenticated = Request.IsAuthenticated;
            HttpCookieCollection httpCookieCollection = Response.Cookies;
            if (Context.User != null)
            {
                //get the username which we previously set in
                //forms authentication ticket in our login1_authenticate event
                string loggedUser = User.Identity.Name;

                
                //set the principal to the current context
                Context.User = new MyPrincipal(loggedUser); 
            }
        }

    }
}
