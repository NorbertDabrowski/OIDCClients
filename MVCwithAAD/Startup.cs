using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCwithAAD.Startup))]
namespace MVCwithAAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
