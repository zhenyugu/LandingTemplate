using DataAccessLayer;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LandingPageWebTemplate.Controllers
{
    public class BaseController : Controller
    {

        private UserManager<IdentityUser> _userManager;

        private IdentityDbContext<IdentityUser> _dbContext;

        public UserManager<IdentityUser> UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
            }
            set
            {
                _userManager = value;
            }
        }

        public IdentityDbContext<IdentityUser> DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().GetUserManager<CustomizedDbContext>();
            }
            set
            {
                _dbContext = value;
            }
        }
	}
}