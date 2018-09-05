using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EpiphanyMusic.WebMvcApp.Startup))]
namespace EpiphanyMusic.WebMvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
