namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        ExpireAt = c.DateTime(nullable: false),
                        Restaurant_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_id, cascadeDelete: true)
                .Index(t => t.Restaurant_id)
                .Index(t => t.Employee_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        CollectRequest_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectRequests", t => t.CollectRequest_id, cascadeDelete: true)
                .Index(t => t.CollectRequest_id);
            
            CreateTable(
                "dbo.FoodParcelTrackings",
                c => new
                    {
                        CollectRequest_id = c.Int(nullable: false),
                        CollectAt = c.DateTime(nullable: false),
                        DistributeAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CollectRequest_id)
                .ForeignKey("dbo.CollectRequests", t => t.CollectRequest_id)
                .Index(t => t.CollectRequest_id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectRequests", "Restaurant_id", "dbo.Restaurants");
            DropForeignKey("dbo.FoodParcelTrackings", "CollectRequest_id", "dbo.CollectRequests");
            DropForeignKey("dbo.FoodItems", "CollectRequest_id", "dbo.CollectRequests");
            DropForeignKey("dbo.CollectRequests", "Employee_id", "dbo.Employees");
            DropIndex("dbo.FoodParcelTrackings", new[] { "CollectRequest_id" });
            DropIndex("dbo.FoodItems", new[] { "CollectRequest_id" });
            DropIndex("dbo.CollectRequests", new[] { "Employee_id" });
            DropIndex("dbo.CollectRequests", new[] { "Restaurant_id" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.FoodParcelTrackings");
            DropTable("dbo.FoodItems");
            DropTable("dbo.Employees");
            DropTable("dbo.CollectRequests");
            DropTable("dbo.Admins");
        }
    }
}
