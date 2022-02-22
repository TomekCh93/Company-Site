using BazaDanychEFDb_firstaproach.Models;
using System;
using System.Data.Entity;

namespace Company.DataLayer
{
    public class CompanyDbContext
    {

        public class CompanyDbContextClass : DbContext
        {
            public CompanyDbContextClass() : base(@"Data Source = (local)\WINCC;Database=Company;Trusted_Connection=True")
            {
            }
            //  private string _connectionString = @"Data Source = (local)\WINCC;Database=RestaurantDB;Trusted_Connection=True";
            public DbSet<Brands> Brands { get; set; }
            public DbSet<Products> Products { get; set; }
            public DbSet<Categories> Categories { get; set; }


        }
    }
}
