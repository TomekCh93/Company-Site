using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DataLayer;
using Company.DomainModels;
using Company.RepositoryContracts;

namespace Company.RepositoryLayer
{
    public class ProductsRepository : IProductsRepository
    {
     
            CompanyDbContext db;
            public ProductsRepository()
            {
                this.db = new CompanyDbContext();
            }
            public void DeleteProduct(Products p)
            {
                Products result = db.Products.Where(id => id.ProductID == p.ProductID).FirstOrDefault();
                db.Products.Remove(result);
                db.SaveChanges();
            }

            public Products GetProductByProductId(int ProductID)
            {
                Products p = db.Products.Where(id => id.ProductID == ProductID).FirstOrDefault();
                return p;
            }

            public Products GetProductByProductId(long ProductID)
            {
                throw new NotImplementedException();
            }

            public List<Products> GetProducts()
            {
                List<Products> products = db.Products.ToList();
                return products;
            }

            public void InsertProduct(Products p)
            {
                db.Products.Add(p);
                db.SaveChanges();
            }

            public List<Products> SearchProducts(string ProductName)
            {
                List<Products> products = db.Products.Where(id => id.ProductName.Contains(ProductName)).ToList();
                return products;
            }

            public void UpdateProduct(Products p)
            {
                Products result = db.Products.Where(id => id.ProductID == p.ProductID).FirstOrDefault();
                result.ProductName = p.ProductName;
                result.Price = p.Price;
                result.DateOfPurchase = p.DateOfPurchase;
                result.CategoryID = p.CategoryID;
                result.BrandID = p.BrandID;
                result.AvailabilityStatus = p.AvailabilityStatus;
                result.Active = p.Active;
                result.Photo = p.Photo;
                db.SaveChanges();
            }
        
    }
}
