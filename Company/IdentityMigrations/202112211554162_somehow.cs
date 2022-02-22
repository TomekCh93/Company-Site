namespace Company_Site.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somehow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "Brithday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Brithday", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "Birthday");
        }
    }
}
