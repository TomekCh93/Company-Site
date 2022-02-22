﻿using Company_Site.Filters;
using Company.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DataLayer;
using Company.ServicesContracts;
using Company.ServieLayer;

namespace Company_Site.Areas.Admin.Controllers
{
    [AdministratorAuthorization]
    public class ProductsController : Controller
    {
        CompanyDbContext db;
        IProductsService prodService;

        public ProductsController(IProductsService pService)
        {
            this.db = new CompanyDbContext();
            this.prodService = pService;
        }

        [HttpGet] 
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int PageNum = 1)
        {
            ViewBag.search = search;
            List<Products> products = prodService.SearchProducts(search);

            #region Sorting
            //*sorting*//
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
                }
            }

            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
                }
            }

            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.Price).ToList();
                }
            }

            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
                }
            }

            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.CategoryID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.CategoryID).ToList();
                }

            }

            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.BrandID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.BrandID).ToList();
                }
            }
            //*sorting*//
            #endregion Region_1
            #region Paging
            //*paging*//
            int NumOfRecordsPerPage = 5;
            int NumOfPages = Convert.ToInt32((Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NumOfRecordsPerPage))));
            int NumOfRecordsToSkip = (PageNum - 1) * NumOfRecordsPerPage;
            ViewBag.PageNum = PageNum;
            ViewBag.NumOfPages = NumOfPages;
            products = products.Skip(NumOfRecordsToSkip).Take(NumOfRecordsPerPage).ToList();
            //*paging*//
            #endregion Paging
            return View(products);
        }


        [HttpGet]
        public ActionResult Details(long id)
        {
        
            Products product = prodService.GetProductByProductId(id);

            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Brands = db.Brands.ToList();
            ViewBag.Categories = db.Categories.ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Price,DateOfPurchase,AvailabilityStatus,CategoryID,BrandID,Active,Photo")] Products p)
        {
  
            if (ModelState.IsValid)
            {



                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }

                prodService.InsertProduct(p);
                return RedirectToAction("Index");
                //return View();
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

   
            Products result = prodService.GetProductByProductId(id);
            ViewBag.Brands = db.Brands.ToList();
            ViewBag.Categories = db.Categories.ToList();

            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Products p)
        {
            if (ModelState.IsValid)
            {
                Products result = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    result.Photo = base64String;
                }
                result.ProductName = p.ProductName;
                result.Price = p.Price;
                result.DateOfPurchase = p.DateOfPurchase;
                result.CategoryID = p.CategoryID;
                result.BrandID = p.BrandID;
                result.AvailabilityStatus = p.AvailabilityStatus;
                result.Active = p.Active;

                prodService.UpdateProduct(result);
            }
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            Products result = prodService.GetProductByProductId(id);     
            return View(result);

        }

        [HttpPost]
        public ActionResult Delete(int id, Products p)
        {


            prodService.DeleteProduct(p);
            return RedirectToAction("Index");

        }
    }
}