namespace Together.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class some : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoutePoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Address = c.String(),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        RouteType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoutePoints", "RouteId", "dbo.Routes");
            DropIndex("dbo.RoutePoints", new[] { "RouteId" });
            DropTable("dbo.Routes");
            DropTable("dbo.RoutePoints");
        }
    }
}
