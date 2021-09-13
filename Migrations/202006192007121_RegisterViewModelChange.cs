namespace Disabled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterViewModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_ZipCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserData_Code", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_ZipCode");
        }
    }
}
