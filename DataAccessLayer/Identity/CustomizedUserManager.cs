using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Identity
{
    public class CustomizedUserManager: UserManager<IdentityUser>
    {
        public CustomizedUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
             
        }

        public static CustomizedUserManager Create(IdentityFactoryOptions<CustomizedUserManager> options, IOwinContext context)
        {
            var manager = new CustomizedUserManager(new UserStore<IdentityUser>(new CustomizedDbContext()));
            manager.UserValidator = new UserValidator<IdentityUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
            };
            manager.UserLockoutEnabledByDefault = false;
            return manager;
        }
    }
}
