namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectRequest_EmployeeId_AllowNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectRequests", "Employee_id", "dbo.Employees");
            DropIndex("dbo.CollectRequests", new[] { "Employee_id" });
            AlterColumn("dbo.CollectRequests", "Employee_id", c => c.Int());
            CreateIndex("dbo.CollectRequests", "Employee_id");
            AddForeignKey("dbo.CollectRequests", "Employee_id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectRequests", "Employee_id", "dbo.Employees");
            DropIndex("dbo.CollectRequests", new[] { "Employee_id" });
            AlterColumn("dbo.CollectRequests", "Employee_id", c => c.Int(nullable: false));
            CreateIndex("dbo.CollectRequests", "Employee_id");
            AddForeignKey("dbo.CollectRequests", "Employee_id", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
