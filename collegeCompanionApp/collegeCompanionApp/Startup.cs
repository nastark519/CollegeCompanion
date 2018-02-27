using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(collegeCompanionApp.Startup))]
namespace collegeCompanionApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
