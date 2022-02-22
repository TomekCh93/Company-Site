using Company.DomainModels;
using Company_Site.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DataLayer;


namespace Company_Site.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        [MyAuthenticationFilter]
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Products> products = db.Products.ToList();
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult DisplaySingleProduct(Products p)
        {

            return PartialView("MyProduct", p);
        }
    }
}