namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToStation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Stations", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Stations", new[] { "Name" });
        }
    }
}
