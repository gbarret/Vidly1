namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateModifiedToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateModified");
        }
    }
}
