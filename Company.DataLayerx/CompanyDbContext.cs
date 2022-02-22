using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Company.DomainModels;

namespace Company.DataLayer
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base(@"Data Source = (local)\WINCC;Database=Company;Trusted_Connection=True") // path connection string
        {
            
        }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}


