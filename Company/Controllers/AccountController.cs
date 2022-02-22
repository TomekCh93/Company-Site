using Company_Site.Identity;
using Company_Site.ViewModels;
using Company.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Company_Site.Filters;

namespace Company_Site.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [ActionName("Register")]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                //register
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser() { Email = rvm.Email, UserName = rvm.Username, PasswordHash = passwordHash, City = rvm.City, Country = rvm.Country, Birthday = rvm.DateOfBirth, Address = rvm.Address, PhoneNumber = rvm.Mobile };
                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id, "Customer");

                    //login
                    GetLogin(userManager, user);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {

            //register
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);


            var user = userManager.Find(lvm.Username, lvm.Password);

            if (user != null)
            {
                //login
                GetLogin(userManager, user);

                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ModelState.AddModelError("myerror", "Invalid username or password");
                return View();
            }
        }



        [HttpGet]
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]

        [MyAuthenticationFilter]
        public ActionResult MyProfile()
        {

            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);

        }

        [HttpGet]
        public void GetLogin(ApplicationUserManager userManager, ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
    }
}
