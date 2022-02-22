using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Company.DataLayer;
using Company_Site.Filters;

namespace Company_Site.Areas.Admin
{
    [AdministratorAuthorization]
    public class BrandsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Brands> brands = db.Brands.ToList(); 
            return View(brands);
        }
    }
}