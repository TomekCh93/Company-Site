using Company_Site.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Company.DataLayer;


namespace Company_Site.Areas.Admin.Controllers
{
    [AdministratorAuthorization]    
    public class CategoriesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            
            List<Categories> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}