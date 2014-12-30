using Microsoft.Owin;
using Owin;
using TheGalery.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace TheGalery.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
