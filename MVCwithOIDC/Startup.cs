using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCwithOIDC.Startup))]
namespace MVCwithOIDC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
