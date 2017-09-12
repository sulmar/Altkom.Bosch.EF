namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStringName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Name", c => c.String());
        }
    }
}
