namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOrderItemEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ProductOrder", "ProductRefId", "dbo.Orders");
            DropForeignKey("dbo.ProductOrder", "OrderRefId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.ProductOrder", new[] { "ProductRefId" });
            DropIndex("dbo.ProductOrder", new[] { "OrderRefId" });
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SerialNumber = c.String(),
                        ProductName = c.String(),
                        Stock = c.Int(nullable: false),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderNumber = c.Guid(),
                        CustomerId = c.Guid(),
                        ProductId = c.Guid(),
                        OrderId = c.Guid(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            DropColumn("dbo.Orders", "SerialNumber");
            DropColumn("dbo.Orders", "ProductName");
            DropColumn("dbo.Orders", "Stock");
            DropColumn("dbo.Orders", "SellingPrice");
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "OrderNumber");
            DropColumn("dbo.Orders", "CustomerId");
            DropTable("dbo.ProductOrder");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        ProductRefId = c.Guid(nullable: false),
                        OrderRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductRefId, t.OrderRefId });
            
            AddColumn("dbo.Orders", "CustomerId", c => c.Guid());
            AddColumn("dbo.Orders", "OrderNumber", c => c.Guid());
            AddColumn("dbo.Orders", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "SellingPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ProductName", c => c.String());
            AddColumn("dbo.Orders", "SerialNumber", c => c.String());
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "CustomerId" });
            DropTable("dbo.OrderItems");
            CreateIndex("dbo.ProductOrder", "OrderRefId");
            CreateIndex("dbo.ProductOrder", "ProductRefId");
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.ProductOrder", "OrderRefId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrder", "ProductRefId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id");
        }
    }
}
