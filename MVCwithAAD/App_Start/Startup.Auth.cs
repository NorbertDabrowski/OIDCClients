using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCwithAAD {
  public partial class Startup {
    public void ConfigureAuth(IAppBuilder app) {

      //var cookieType = CookieAuthenticationDefaults.AuthenticationType; //"Cookies";
      var cookieType = DefaultAuthenticationTypes.ApplicationCookie;
      //var cookieType = DefaultAuthenticationTypes.ExternalCookie;

      app.UseCookieAuthentication(new CookieAuthenticationOptions {
        AuthenticationType = cookieType,
        CookieName = "MVCcookieOIDaad"
      });

      // HYBRID
      app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
        SignInAsAuthenticationType = cookieType,

        Authority = "https://localhost:44334",
        RequireHttpsMetadata = false,
        RedirectUri = "http://localhost:58927/signin-oidc",
        PostLogoutRedirectUri = "http://localhost:58927/signout-callback-oidc",

        ClientId = "mvc4netaad.hybrid",
        ClientSecret = "secret",
                
        ResponseType = OpenIdConnectResponseType.CodeIdToken, //"code id_token"

        //Scope = "openid profile email api1 api2.read_only",
        Scope = "openid profile",

        //Notifications = new OpenIdConnectAuthenticationNotifications {
        //  SecurityTokenValidated = notification => {
        //    notification.AuthenticationTicket.Identity.AddClaim(new Claim("id_token", notification.ProtocolMessage.IdToken));
        //    //notification.AuthenticationTicket.Identity.AddClaim(new Claim("access_token", notification.ProtocolMessage.AccessToken));

        //    return Task.FromResult(0);
        //  },

        //  RedirectToIdentityProvider = notification => {
        //    notification.ProtocolMessage.RedirectUri = notification.OwinContext.Request.Uri.Host;
        //    notification.ProtocolMessage.PostLogoutRedirectUri = notification.OwinContext.Request.Uri.Host;
          
        //    return Task.FromResult(0);
        //  }
        //}
      });

      //RESOURCE OWNER PASSWORD
      //app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
      //  Authority = "https://localhost:44334",
      //  ClientId = "webadmin.roclient",
      //  ClientSecret = "secret",
      //  ResponseType = "id_token",
      //  SignInAsAuthenticationType = cookieType,
      //  RedirectUri = "http://localhost:58927/signin-oidc",
      //  Scope = "openid"
      //});
    }
  }

}