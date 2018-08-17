using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epiphany_Music_App_1._0.WEBMVC.Startup))]
namespace Epiphany_Music_App_1._0.WEBMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
