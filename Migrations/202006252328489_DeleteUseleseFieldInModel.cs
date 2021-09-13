namespace Disabled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUseleseFieldInModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderItems", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "AlbumId", c => c.Int(nullable: false));
        }
    }
}
