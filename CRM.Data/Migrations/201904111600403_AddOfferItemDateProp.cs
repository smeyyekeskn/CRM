namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfferItemDateProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferItems", "RegisterRequiredDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferItems", "RegisterRequiredDate");
        }
    }
}
