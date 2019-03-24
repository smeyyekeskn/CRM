namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesAtEmployeeEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserType", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "UserType");
        }
    }
}
