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
using DataAccessLayer.Identity;

namespace LandingPageWebTemplate.Controllers
{
    public class BaseController : Controller
    {

        private CustomizedUserManager _userManager;

        private CustomizedSignManager _signInManager;

        private CustomizedDbContext _dbContext;

        public CustomizedUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<CustomizedUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public CustomizedSignManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<CustomizedSignManager>();
            }
            set
            {
                _signInManager = value;
            }
        }

        public CustomizedDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().Get<CustomizedDbContext>();
            }
            set
            {
                _dbContext = value;
            }
        }
	}
}