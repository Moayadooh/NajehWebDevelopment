using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_Identity_Individual_User_Accounts.Startup))]
namespace ASP_Identity_Individual_User_Accounts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
