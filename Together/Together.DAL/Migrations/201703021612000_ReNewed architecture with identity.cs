namespace Together.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReNewedarchitecturewithidentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.UserId })
                .ForeignKey("dbo.Group", t => t.GroupId)
                .ForeignKey("dbo.AppUser", t => t.UserId)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
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
                .ForeignKey("dbo.AppUser", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.RoutePoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggestDate = c.DateTime(nullable: false),
                        ConfirmDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                        ListOrder = c.Int(),
                        SuggestUserId = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Address = c.String(),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Route", t => t.RouteId)
                .ForeignKey("dbo.AppUser", t => t.SuggestUserId)
                .Index(t => t.SuggestUserId)
                .Index(t => t.RouteId);
            
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
                .ForeignKey("dbo.AppUser", t => t.OwnerId)
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
                .ForeignKey("dbo.AppUser", t => t.UserId)
                .Index(t => t.RouteId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AppUser", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RoutePoint", "SuggestUserId", "dbo.AppUser");
            DropForeignKey("dbo.RouteUser", "UserId", "dbo.AppUser");
            DropForeignKey("dbo.RouteUser", "RouteId", "dbo.Route");
            DropForeignKey("dbo.RoutePoint", "RouteId", "dbo.Route");
            DropForeignKey("dbo.Route", "OwnerId", "dbo.AppUser");
            DropForeignKey("dbo.GroupUser", "UserId", "dbo.AppUser");
            DropForeignKey("dbo.Group", "OwnerId", "dbo.AppUser");
            DropForeignKey("dbo.GroupUser", "GroupId", "dbo.Group");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RouteUser", new[] { "UserId" });
            DropIndex("dbo.RouteUser", new[] { "RouteId" });
            DropIndex("dbo.Route", new[] { "OwnerId" });
            DropIndex("dbo.RoutePoint", new[] { "RouteId" });
            DropIndex("dbo.RoutePoint", new[] { "SuggestUserId" });
            DropIndex("dbo.Group", new[] { "OwnerId" });
            DropIndex("dbo.GroupUser", new[] { "UserId" });
            DropIndex("dbo.GroupUser", new[] { "GroupId" });
            DropIndex("dbo.AppUser", new[] { "User_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Point");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.RouteUser");
            DropTable("dbo.Route");
            DropTable("dbo.RoutePoint");
            DropTable("dbo.Group");
            DropTable("dbo.GroupUser");
            DropTable("dbo.AppUser");
        }
    }
}
