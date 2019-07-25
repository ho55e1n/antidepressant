namespace AntiDepressantWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class increatestringlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiaryEntries", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiaryEntries", "Text", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
