using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DCMP_WEB.Startup))]
namespace DCMP_WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
