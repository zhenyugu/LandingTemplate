using DataAccessLayer.Model;
using LandingPageWebTemplate.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LandingPageWebTemplate.Controllers
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

         //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var result = SignInManager.PasswordSignIn(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("UserManagement");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "登陆失败，请检查您的用户名或密码");
                    return View(model);
            }
        }
        [Authorize]
        public ActionResult UserManagement()
        {

            List<Production> productionsWithImage = DbContext.Productions.Include(p => p.Images).ToList();
            
            return View(productionsWithImage);
        }
        public ActionResult DeleteImage(string Id)
        {
            if (!DbContext.Productions.Any(p => p.Id == Id))
            {
                ModelState.AddModelError("", "修改失败，未找到对应的作品");
                return RedirectToAction("UserManagement");
            }
            var dbProduct = DbContext.Productions.First(p => p.Id == Id);
            DbContext.Productions.Remove(dbProduct);
            DbContext.SaveChanges();
            return RedirectToAction("UserManagement");
        }

        public ActionResult EditImage(Production production)
        {
            if (!DbContext.Productions.Any(p => p.Id == production.Id))
            {
                ModelState.AddModelError("", "修改失败，未找到对应的作品");
                return RedirectToAction("UserManagement");
            }
            var dbProduct = DbContext.Productions.First(p => p.Id == production.Id);
            dbProduct.Name = production.Name;
            dbProduct.SerialNumber = production.SerialNumber;
            dbProduct.Size = production.Size;
            dbProduct.Weight = production.Weight;
            dbProduct.Author = production.Author;
            dbProduct.Description = production.Description;
            DbContext.SaveChanges();
            return RedirectToAction("UserManagement");
        }

        public ActionResult AddImage(FormCollection collection, HttpPostedFileBase image)
        {

            var product = new Production
            {
                Name = collection["Name"],
                Description = collection["Description"],
                SerialNumber = collection["SerialNumber"],
                Size = collection["Size"],
                Weight = collection["Weight"]
            };
            
            //if (System.IO.File.Exists(fullPath))
            //{
            //    System.IO.File.Delete(fullPath);
            //    //Session["DeleteSuccess"] = "Yes";
            //}
            var contextType = image.ContentType;
            if (contextType == "image/jpeg" ||  contextType == "image/png")
            {
                contextType = contextType.Replace("image/", ".");
            }
            else
            {
                ModelState.AddModelError("", "添加失败,图片格式仅支持jpeg,png");
                return RedirectToAction("UserManagement");
            }
            string path = "~/Content/images/display/" + collection["Name"] + contextType;
            string fullPath = Request.MapPath(path);
            image.SaveAs(fullPath);
            DbContext.Set<Production>().Add(product);
            DbContext.Set<ProductionImage>().Add(new ProductionImage
            {
                ProductionId = product.Id,
                ImageAddress = path.Substring(1,path.Length - 1)
            });
            DbContext.SaveChanges();
            return RedirectToAction("UserManagement");
        }
    }
}