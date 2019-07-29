namespace Together.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        MaxPassengers = c.Int(nullable: false),
                        PassengersCount = c.Int(nullable: false),
                        RouteType = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Passengers", "RouteId", "dbo.Routes");
            DropIndex("dbo.Passengers", new[] { "UserId" });
            DropIndex("dbo.Passengers", new[] { "RouteId" });
            DropTable("dbo.Users");
            DropTable("dbo.Routes");
            DropTable("dbo.Passengers");
        }
    }
}
