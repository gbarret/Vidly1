namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMyPropertyFromCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
