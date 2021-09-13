namespace Disabled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProducerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProducerId");
        }
    }
}
