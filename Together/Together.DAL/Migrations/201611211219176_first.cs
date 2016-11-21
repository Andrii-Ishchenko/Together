namespace Together.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                        SecretKey = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.UserId })
                .ForeignKey("dbo.Group", t => t.GroupId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoutePoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggestDate = c.DateTime(nullable: false),
                        ConfirmDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                        RoutePointOrder = c.Int(),
                        SuggestUserId = c.Int(nullable: false),
                        PointId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Point", t => t.PointId)
                .ForeignKey("dbo.Route", t => t.RouteId)
                .ForeignKey("dbo.User", t => t.SuggestUserId)
                .Index(t => t.SuggestUserId)
                .Index(t => t.PointId)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.Point",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        MaxPassengers = c.Int(nullable: false),
                        RouteType = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                        SecretKey = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.RouteUser",
                c => new
                    {
                        RouteId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.RouteId, t.UserId })
                .ForeignKey("dbo.Route", t => t.RouteId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.RouteId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Group", "OwnerId", "dbo.User");
            DropForeignKey("dbo.RoutePoint", "SuggestUserId", "dbo.User");
            DropForeignKey("dbo.RouteUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RouteUser", "RouteId", "dbo.Route");
            DropForeignKey("dbo.RoutePoint", "RouteId", "dbo.Route");
            DropForeignKey("dbo.Route", "OwnerId", "dbo.User");
            DropForeignKey("dbo.RoutePoint", "PointId", "dbo.Point");
            DropForeignKey("dbo.GroupUser", "UserId", "dbo.User");
            DropForeignKey("dbo.GroupUser", "GroupId", "dbo.Group");
            DropIndex("dbo.RouteUser", new[] { "UserId" });
            DropIndex("dbo.RouteUser", new[] { "RouteId" });
            DropIndex("dbo.Route", new[] { "OwnerId" });
            DropIndex("dbo.RoutePoint", new[] { "RouteId" });
            DropIndex("dbo.RoutePoint", new[] { "PointId" });
            DropIndex("dbo.RoutePoint", new[] { "SuggestUserId" });
            DropIndex("dbo.GroupUser", new[] { "UserId" });
            DropIndex("dbo.GroupUser", new[] { "GroupId" });
            DropIndex("dbo.Group", new[] { "OwnerId" });
            DropTable("dbo.RouteUser");
            DropTable("dbo.Route");
            DropTable("dbo.Point");
            DropTable("dbo.RoutePoint");
            DropTable("dbo.User");
            DropTable("dbo.GroupUser");
            DropTable("dbo.Group");
        }
    }
}
