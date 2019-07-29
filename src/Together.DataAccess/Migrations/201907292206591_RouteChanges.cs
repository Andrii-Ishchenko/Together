namespace Together.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RouteChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Routes", "PassengersCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "PassengersCount", c => c.Int(nullable: false));
        }
    }
}
