namespace Together.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoutePoints : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoutePoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        Name = c.String(),
                        OrderNumber = c.Int(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Latitude = c.Single(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.CreatorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoutePoints", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.RoutePoints", "CreatorId", "dbo.Users");
            DropIndex("dbo.RoutePoints", new[] { "CreatorId" });
            DropIndex("dbo.RoutePoints", new[] { "RouteId" });
            DropTable("dbo.RoutePoints");
        }
    }
}
