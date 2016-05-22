using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using DataAccessLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataAccessLayer.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(LandingPageWebTemplate.Startup))]

namespace LandingPageWebTemplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(CustomizedDbContext.Create);
            app.CreatePerOwinContext<CustomizedUserManager>(CustomizedUserManager.Create);
            app.CreatePerOwinContext<CustomizedSignManager>(CustomizedSignManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<CustomizedUserManager, IdentityUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie))
                }
            });
        }
    }
}
