using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCwithOIDCtoAAD.Startup))]
namespace MVCwithOIDCtoAAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
