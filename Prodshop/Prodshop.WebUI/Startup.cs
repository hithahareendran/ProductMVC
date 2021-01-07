using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prodshop.WebUI.Startup))]
namespace Prodshop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
