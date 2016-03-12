using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Intercity.Startup))]
namespace Intercity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
