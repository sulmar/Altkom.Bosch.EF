namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stations", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stations", "Name", c => c.String());
        }
    }
}
