namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "VehicleType", c => c.String(nullable: false, maxLength: 128));

            Sql("UPDATE dbo.Vehicles SET VehicleType = LEFT(Discriminator, 1)");

            DropColumn("dbo.Vehicles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Vehicles", "VehicleType");
        }
    }
}
