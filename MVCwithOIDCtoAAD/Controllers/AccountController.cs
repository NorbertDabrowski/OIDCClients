using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using MVCwithOIDCtoAAD.Models;

namespace MVCwithOIDCtoAAD.Controllers {
  //  [Authorize]
  public class AccountController : Controller {

    public void SignIn() {
      // Send an OpenID Connect sign-in request.
      if (!Request.IsAuthenticated) {
        HttpContext.GetOwinContext().Authentication.Challenge(
          new AuthenticationProperties { RedirectUri = "/" },
          OpenIdConnectAuthenticationDefaults.AuthenticationType);
      }
    }

    public void SignOut() {
      string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);

      HttpContext.GetOwinContext().Authentication.SignOut(
          new AuthenticationProperties { RedirectUri = callbackUrl },
          OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);

      //HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
    }

    public ActionResult SignOutCallback() {
      //if (Request.IsAuthenticated) {
      // Redirect to home page if the user is authenticated.
      return RedirectToAction("Index", "Home");
      //}

      //  return View();
    }


  }
}