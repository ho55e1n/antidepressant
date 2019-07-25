namespace AntiDepressantWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeoLocationProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GeoLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GeoLocation");
        }
    }
}
