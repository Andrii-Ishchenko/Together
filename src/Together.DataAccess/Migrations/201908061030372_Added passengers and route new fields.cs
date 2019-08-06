namespace Together.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpassengersandroutenewfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "CreatorId", c => c.Int(nullable: false));
            AddColumn("dbo.Routes", "Name", c => c.String());
            CreateIndex("dbo.Routes", "CreatorId");
            AddForeignKey("dbo.Routes", "CreatorId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "CreatorId", "dbo.Users");
            DropIndex("dbo.Routes", new[] { "CreatorId" });
            DropColumn("dbo.Routes", "Name");
            DropColumn("dbo.Routes", "CreatorId");
        }
    }
}
