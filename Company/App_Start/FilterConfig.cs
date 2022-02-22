using Company_Site.Filters;
using System;
using System.Web.Mvc;

namespace Company_Site
{
    public class FilterConfig
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionFilter()); // exception filter with logic to store error log  

            filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(Exception), View = "Error" }); // only redirects to error page
        }
    }
}