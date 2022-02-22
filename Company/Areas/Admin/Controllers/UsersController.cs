using Company_Site.Filters;
using Company_Site.Identity;
using Company.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company_Site.Areas.Admin.Controllers
{
    [AdministratorAuthorization]
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ApplicationUser> exisingUsers = db.Users.ToList();
            return View(exisingUsers);
        }
    }
}