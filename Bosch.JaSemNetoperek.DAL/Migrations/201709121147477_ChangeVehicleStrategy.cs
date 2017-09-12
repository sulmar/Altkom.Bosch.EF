namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVehicleStrategy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        VehicleId = c.Int(nullable: false),
                        HasBidon = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.MotorBikes",
                c => new
                    {
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            AddColumn("dbo.Vehicles", "Discriminator", c => c.String(maxLength: 128));
            DropColumn("dbo.Vehicles", "HasBidon");
            DropColumn("dbo.Vehicles", "VehicleType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "VehicleType", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Vehicles", "HasBidon", c => c.Boolean());
            DropForeignKey("dbo.MotorBikes", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Bikes", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Airplanes", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Cars", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.MotorBikes", new[] { "VehicleId" });
            DropIndex("dbo.Bikes", new[] { "VehicleId" });
            DropIndex("dbo.Airplanes", new[] { "VehicleId" });
            DropIndex("dbo.Cars", new[] { "VehicleId" });
            DropColumn("dbo.Vehicles", "Discriminator");
            DropTable("dbo.MotorBikes");
            DropTable("dbo.Bikes");
            DropTable("dbo.Airplanes");
            DropTable("dbo.Cars");
        }
    }
}
