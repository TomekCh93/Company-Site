using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Company_Site.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base(@"Data Source = (local)\WINCC;Database=IdentityDatabase;Trusted_Connection=True")
        {
            

        }

    }
}



