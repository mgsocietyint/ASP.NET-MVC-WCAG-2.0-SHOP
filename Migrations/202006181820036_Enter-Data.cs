namespace Disabled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnterData : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Products", "ProducerId");
        }

        public override void Down()
        {
            //AddColumn("dbo.Products", "ProducerId", c => c.Int(nullable: false));
        }
    }
}
