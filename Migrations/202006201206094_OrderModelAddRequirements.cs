namespace Disabled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModelAddRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Orders", "ZipCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Comment", c => c.String(maxLength: 100));
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 17));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Orders", "ZipCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
