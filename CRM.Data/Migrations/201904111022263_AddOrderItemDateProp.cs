namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItemDateProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "RegisterRequiredDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "RegisterRequiredDate");
        }
    }
}
