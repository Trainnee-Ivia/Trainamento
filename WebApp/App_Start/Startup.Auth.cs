using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using WebApp.Models;

namespace WebApp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Acesso/Login"),
                ExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToDouble(30)),
                CookieName = "TraimentoIvia"
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        
        }
    }
}