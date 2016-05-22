using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Identity
{
    public class CustomizedSignManager : SignInManager<IdentityUser, string>
    {
        public CustomizedSignManager(CustomizedUserManager userManager, IAuthenticationManager authenticationManager):base(userManager,authenticationManager)
        {

        }

        public override Task<System.Security.Claims.ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        {
            return base.CreateUserIdentityAsync(user);
        }

        public static CustomizedSignManager Create(IdentityFactoryOptions<CustomizedSignManager> options, IOwinContext context)
        {
            return new CustomizedSignManager(context.GetUserManager<CustomizedUserManager>(), context.Authentication);
        }
    }
}
