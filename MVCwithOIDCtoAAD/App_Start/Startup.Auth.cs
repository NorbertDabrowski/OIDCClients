using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using MVCwithOIDCtoAAD.Models;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MVCwithOIDCtoAAD {
  public partial class Startup {

    private static string clientId = "dc7b2433-36f9-4ffa-9565-82d22ba83a02";
    private static string appKey = "M4DKc4rhG3o+DzFPUMo54e3pqnj1qt7YJ2/9uZGx63c=";
    private static string aadInstance = "https://login.microsoftonline.com/";
    private static string tenantId = "b5313c9d-fb0d-47af-bc87-7c050bffbdc3";
    private static string postLogoutRedirectUri = "http://localhost:58937/";
    private static string domain = "totalmobile.co.uk";

    public static readonly string Authority = aadInstance + tenantId;

    // This is the resource ID of the AAD Graph API.  We'll need this to request a token to call the Graph API.
    string graphResourceId = "https://graph.windows.net/";

    public void ConfigureAuth(IAppBuilder app) {

      //var cookieType = CookieAuthenticationDefaults.AuthenticationType; //"Cookies";
      //var cookieType = DefaultAuthenticationTypes.ExternalCookie;
      //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

      //var cookieType = DefaultAuthenticationTypes.ApplicationCookie;
      //app.UseCookieAuthentication(new CookieAuthenticationOptions {
      //  AuthenticationType = cookieType,
      //  CookieName = "MVCcookieOIDC"
      //});

      app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

      app.UseCookieAuthentication(new CookieAuthenticationOptions());

      app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
        Caption = "Azure AD ***custom***",
        SignInAsAuthenticationType = CookieAuthenticationDefaults.AuthenticationType,

        ClientId = clientId,
        Authority = Authority,
        PostLogoutRedirectUri = postLogoutRedirectUri,

        Notifications = new OpenIdConnectAuthenticationNotifications() {
          // If there is a code in the OpenID Connect response, redeem it for an access token and refresh token, and store those away.
          AuthorizationCodeReceived = (context) => {
            //var code = context.Code;
            //ClientCredential credential = new ClientCredential(clientId, appKey);
            //string signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            //AuthenticationContext authContext = new AuthenticationContext(Authority, new ADALTokenCache(signedInUserID));
            //return authContext.AcquireTokenByAuthorizationCodeAsync(
            //    code, new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, graphResourceId);
            return Task.Run(() => { });
          },

          AuthenticationFailed = (context) => {
            return Task.Run(() => { });
          },
          MessageReceived = (context) => {
            return Task.Run(() => { });
          },
          RedirectToIdentityProvider = (context) => {
            return Task.Run(() => { });
          },
          SecurityTokenReceived = (context) => {
            return Task.Run(() => { });
          },
          SecurityTokenValidated = (context) => {
            return Task.Run(() => { });
          },
        }

        //public Func<AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>, Task> AuthenticationFailed { get; set; }
        //public Func<AuthorizationCodeReceivedNotification, Task> AuthorizationCodeReceived { get; set; }
        //public Func<MessageReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>, Task> MessageReceived { get; set; }
        //public Func<RedirectToIdentityProviderNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>, Task> RedirectToIdentityProvider { get; set; }
        //public Func<SecurityTokenReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>, Task> SecurityTokenReceived { get; set; }
        //public Func<SecurityTokenValidatedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>, Task> SecurityTokenValidated { get; set; }
      });
    }
  }

}