namespace Together.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsOwner = c.Boolean(nullable: false),
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
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
                "dbo.RouteUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        IsRouteOwner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Route", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        RouteType = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.RoutePoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggestDate = c.DateTime(nullable: false),
                        ConfirmDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                        Order = c.Int(),
                        SuggestUserId = c.Int(nullable: false),
                        PointId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Point", t => t.PointId, cascadeDelete: true)
                .ForeignKey("dbo.Route", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.SuggestUserId, cascadeDelete: true)
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RouteUser", "RouteId", "dbo.Route");
            DropForeignKey("dbo.RoutePoint", "SuggestUserId", "dbo.User");
            DropForeignKey("dbo.RoutePoint", "RouteId", "dbo.Route");
            DropForeignKey("dbo.RoutePoint", "PointId", "dbo.Point");
            DropForeignKey("dbo.Route", "GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupUser", "UserId", "dbo.User");
            DropForeignKey("dbo.GroupUser", "GroupId", "dbo.Group");
            DropIndex("dbo.RoutePoint", new[] { "RouteId" });
            DropIndex("dbo.RoutePoint", new[] { "PointId" });
            DropIndex("dbo.RoutePoint", new[] { "SuggestUserId" });
            DropIndex("dbo.Route", new[] { "GroupId" });
            DropIndex("dbo.RouteUser", new[] { "UserId" });
            DropIndex("dbo.RouteUser", new[] { "RouteId" });
            DropIndex("dbo.GroupUser", new[] { "UserId" });
            DropIndex("dbo.GroupUser", new[] { "GroupId" });
            DropTable("dbo.Point");
            DropTable("dbo.RoutePoint");
            DropTable("dbo.Route");
            DropTable("dbo.RouteUser");
            DropTable("dbo.User");
            DropTable("dbo.GroupUser");
            DropTable("dbo.Group");
        }
    }
}
