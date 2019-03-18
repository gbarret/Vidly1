namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirtdateInCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1/1/1980' WHERE Id = 1 ");
            Sql("UPDATE Customers SET Birthdate = '' WHERE Id = 2 ");
        }
        
        public override void Down()
        {
        }
    }
}
