using Company.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.ServicesContracts
{
    public interface IProductsService
    {
         List<Products> GetProducts();
        List<Products> SearchProducts(string ProductName);
        Products GetProductByProductId(long ProductID);
        void InsertProduct(Products p);
        void UpdateProduct(Products p);
        void DeleteProduct(Products p);


    }
}
