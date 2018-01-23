using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GESTAD.Startup))]
namespace GESTAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
