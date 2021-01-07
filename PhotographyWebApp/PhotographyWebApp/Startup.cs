using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotographyWebApp.Startup))]
namespace PhotographyWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
