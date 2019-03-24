namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Iban", c => c.String());
            AddColumn("dbo.Orders", "CustomerId", c => c.Guid());
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id");
            DropColumn("dbo.Orders", "RequiredDate");
            DropColumn("dbo.Orders", "Name");
            DropColumn("dbo.Orders", "Iban");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Iban", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "RequiredDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Customers", "Iban");
        }
    }
}
