namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodParcelTrackings", "CollectRequest_id", "dbo.CollectRequests");
            DropIndex("dbo.FoodParcelTrackings", new[] { "CollectRequest_id" });
            DropTable("dbo.FoodParcelTrackings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FoodParcelTrackings",
                c => new
                    {
                        CollectRequest_id = c.Int(nullable: false),
                        CollectAt = c.DateTime(nullable: false),
                        DistributeAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CollectRequest_id);
            
            CreateIndex("dbo.FoodParcelTrackings", "CollectRequest_id");
            AddForeignKey("dbo.FoodParcelTrackings", "CollectRequest_id", "dbo.CollectRequests", "Id");
        }
    }
}
