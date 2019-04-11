namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSomeEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Offers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ProductOffer", "ProductRefId", "dbo.Offers");
            DropForeignKey("dbo.ProductOffer", "OfferRefId", "dbo.Products");
            DropIndex("dbo.Offers", new[] { "CustomerId" });
            DropIndex("dbo.Offers", new[] { "EmployeeId" });
            DropIndex("dbo.ProductOffer", new[] { "ProductRefId" });
            DropIndex("dbo.ProductOffer", new[] { "OfferRefId" });
            CreateTable(
                "dbo.OfferItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SerialNumber = c.String(),
                        ProductName = c.String(),
                        Stock = c.Int(nullable: false),
                        OfferPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Guid(),
                        ProductId = c.Guid(),
                        OfferId = c.Guid(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Employee_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.OfferId)
                .Index(t => t.Employee_Id);
            
            DropColumn("dbo.Offers", "Description");
            DropColumn("dbo.Offers", "Amount");
            DropColumn("dbo.Offers", "CustomerId");
            DropColumn("dbo.Offers", "EmployeeId");
            DropColumn("dbo.OrderItems", "OrderNumber");
            DropTable("dbo.ProductOffer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductOffer",
                c => new
                    {
                        ProductRefId = c.Guid(nullable: false),
                        OfferRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductRefId, t.OfferRefId });
            
            AddColumn("dbo.OrderItems", "OrderNumber", c => c.Guid());
            AddColumn("dbo.Offers", "EmployeeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Offers", "CustomerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Offers", "Amount", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Offers", "Description", c => c.String(nullable: false, maxLength: 1000));
            DropForeignKey("dbo.OfferItems", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.OfferItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OfferItems", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.OfferItems", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OfferItems", new[] { "Employee_Id" });
            DropIndex("dbo.OfferItems", new[] { "OfferId" });
            DropIndex("dbo.OfferItems", new[] { "ProductId" });
            DropIndex("dbo.OfferItems", new[] { "CustomerId" });
            DropTable("dbo.OfferItems");
            CreateIndex("dbo.ProductOffer", "OfferRefId");
            CreateIndex("dbo.ProductOffer", "ProductRefId");
            CreateIndex("dbo.Offers", "EmployeeId");
            CreateIndex("dbo.Offers", "CustomerId");
            AddForeignKey("dbo.ProductOffer", "OfferRefId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductOffer", "ProductRefId", "dbo.Offers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Offers", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Offers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
