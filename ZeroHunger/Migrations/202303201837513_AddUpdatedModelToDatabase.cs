namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdatedModelToDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodItems", "CollectRequest_id", "dbo.CollectRequests");
            DropIndex("dbo.FoodItems", new[] { "CollectRequest_id" });
            AddColumn("dbo.CollectRequests", "Name", c => c.String());
            AddColumn("dbo.CollectRequests", "Quantity", c => c.Int(nullable: false));
            DropTable("dbo.FoodItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        CollectRequest_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.CollectRequests", "Quantity");
            DropColumn("dbo.CollectRequests", "Name");
            CreateIndex("dbo.FoodItems", "CollectRequest_id");
            AddForeignKey("dbo.FoodItems", "CollectRequest_id", "dbo.CollectRequests", "Id", cascadeDelete: true);
        }
    }
}
