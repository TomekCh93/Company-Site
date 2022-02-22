using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.ServieLayer;
using Company.DataLayer;
using Company.ServicesContracts;
using Company.DomainModels;
using Company.RepositoryContracts;

namespace Company.ServieLayer
{
    public class ProductService : IProductsService
    {
        IProductsRepository prodRep;
        public ProductService(IProductsRepository r)
        {
            this.prodRep = r;   
        }
        public void DeleteProduct(Products p)
        {
            prodRep.DeleteProduct(p);
        }

        public Products GetProductByProductId(int ProductID)
        {
            Products p = prodRep.GetProductByProductId(ProductID);
            return p;
        }

        public Products GetProductByProductId(long ProductID)
        {
            Products p = prodRep.GetProductByProductId(ProductID);
            return p;
        }

        public List<Products> GetProducts()
        {
            List<Products> products = prodRep.GetProducts();
            return products;
        }

        public void InsertProduct(Products p)
        {
            if (p.Price <= 100000)
            {
                prodRep.InsertProduct(p);
            }
            else
            {
                throw new Exception("Price exceeds the limit");
            }
          
        }

        public List<Products> SearchProducts(string ProductName)
        {
            List<Products> products = prodRep.SearchProducts(ProductName);
            return products;
        }

        public void UpdateProduct(Products p)
        {
            prodRep.UpdateProduct(p);
        }
    }    
}
