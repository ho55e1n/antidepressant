namespace AntiDepressantWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexcersize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Location = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Exercises", new[] { "UserId" });
            DropTable("dbo.Exercises");
        }
    }
}
