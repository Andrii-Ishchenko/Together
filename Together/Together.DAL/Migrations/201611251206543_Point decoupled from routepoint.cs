namespace Together.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pointdecoupledfromroutepoint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoutePoint", "PointId", "dbo.Point");
            DropIndex("dbo.RoutePoint", new[] { "PointId" });
            AddColumn("dbo.RoutePoint", "ListOrder", c => c.Int());
            AddColumn("dbo.RoutePoint", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.RoutePoint", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.RoutePoint", "Adress", c => c.String());
            DropColumn("dbo.RoutePoint", "RoutePointOrder");
            DropColumn("dbo.RoutePoint", "PointId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoutePoint", "PointId", c => c.Int(nullable: false));
            AddColumn("dbo.RoutePoint", "RoutePointOrder", c => c.Int());
            DropColumn("dbo.RoutePoint", "Adress");
            DropColumn("dbo.RoutePoint", "Longitude");
            DropColumn("dbo.RoutePoint", "Latitude");
            DropColumn("dbo.RoutePoint", "ListOrder");
            CreateIndex("dbo.RoutePoint", "PointId");
            AddForeignKey("dbo.RoutePoint", "PointId", "dbo.Point", "Id");
        }
    }
}
