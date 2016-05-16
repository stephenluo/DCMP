using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DCMP.Startup))]
namespace DCMP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
