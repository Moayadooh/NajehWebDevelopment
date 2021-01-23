using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_Identity_Inegrated_DB.Startup))]
namespace ASP_Identity_Inegrated_DB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
