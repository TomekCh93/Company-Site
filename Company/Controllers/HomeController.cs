﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company_Site.Filters;

namespace Company_Site.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
       
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }
    }
}