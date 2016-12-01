namespace Together.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addresstypo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoutePoint", "Address", c => c.String());
            DropColumn("dbo.RoutePoint", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoutePoint", "Adress", c => c.String());
            DropColumn("dbo.RoutePoint", "Address");
        }
    }
}
