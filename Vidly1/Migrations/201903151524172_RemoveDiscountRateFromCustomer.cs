namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDiscountRateFromCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DiscountRate", c => c.Byte(nullable: false));
        }
    }
}
