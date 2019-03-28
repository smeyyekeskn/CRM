namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtoOrderEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SerialNumber", c => c.String());
            AddColumn("dbo.Orders", "ProductName", c => c.String());
            AddColumn("dbo.Orders", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Stock");
            DropColumn("dbo.Orders", "ProductName");
            DropColumn("dbo.Orders", "SerialNumber");
        }
    }
}
