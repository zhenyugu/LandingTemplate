using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



namespace LandingPageWebTemplate.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Products()        
        {
            List<Production> productionsWithImage = DbContext.Productions.Include(p => p.Images).ToList();

            return View(productionsWithImage);
        }

        public ActionResult Culture()
        {
            return View();
        }
        public ActionResult ProductQuery(string serialNumber)
        {
            var production = DbContext.Productions.FirstOrDefault(r => r.SerialNumber == serialNumber);
            return View(production);
        }

        public ActionResult QueryBySerialNumber(string serialNumber)
        {
            var result = DbContext.Productions.Include(p => p.Images).FirstOrDefault(r => r.SerialNumber == serialNumber);
            //  var result= DbContext.Productions.FirstOrDefault(r => r.SerialNumber == serialNumber);
            return View("ProductResult", result);
        }
    }
}