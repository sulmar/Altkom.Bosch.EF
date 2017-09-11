namespace Bosch.JaSemNetoperek.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        FromStation_StationId = c.Int(),
                        Rentee_UserId = c.Int(),
                        ToStation_StationId = c.Int(),
                        Vehicle_VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.Stations", t => t.FromStation_StationId)
                .ForeignKey("dbo.Users", t => t.Rentee_UserId)
                .ForeignKey("dbo.Stations", t => t.ToStation_StationId)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_VehicleId)
                .Index(t => t.FromStation_StationId)
                .Index(t => t.Rentee_UserId)
                .Index(t => t.ToStation_StationId)
                .Index(t => t.Vehicle_VehicleId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Byte(nullable: false),
                        Location_Latitude = c.Single(nullable: false),
                        Location_Longitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.StationId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location_Latitude = c.Single(nullable: false),
                        Location_Longitude = c.Single(nullable: false),
                        HasBidon = c.Boolean(),
                        EngineCapacity = c.Single(),
                        MaxSpeed = c.Int(),
                        EngineType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Station_StationId = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Stations", t => t.Station_StationId)
                .Index(t => t.Station_StationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Vehicle_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Station_StationId", "dbo.Stations");
            DropForeignKey("dbo.Rentals", "ToStation_StationId", "dbo.Stations");
            DropForeignKey("dbo.Rentals", "Rentee_UserId", "dbo.Users");
            DropForeignKey("dbo.Rentals", "FromStation_StationId", "dbo.Stations");
            DropIndex("dbo.Vehicles", new[] { "Station_StationId" });
            DropIndex("dbo.Rentals", new[] { "Vehicle_VehicleId" });
            DropIndex("dbo.Rentals", new[] { "ToStation_StationId" });
            DropIndex("dbo.Rentals", new[] { "Rentee_UserId" });
            DropIndex("dbo.Rentals", new[] { "FromStation_StationId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Users");
            DropTable("dbo.Stations");
            DropTable("dbo.Rentals");
        }
    }
}
