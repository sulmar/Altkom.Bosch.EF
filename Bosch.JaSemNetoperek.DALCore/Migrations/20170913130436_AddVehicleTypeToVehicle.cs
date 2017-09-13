using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bosch.JaSemNetoperek.DALCore.Migrations
{
    public partial class AddVehicleTypeToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "VehicleType",
              table: "Vehicles",
              type: "nvarchar(max)",
              nullable: false,
              defaultValue: "");

            migrationBuilder.Sql("UPDATE dbo.Vehicles SET VehicleType = LEFT(Discriminator, 1)");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vehicles");

            

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");
        }
    }
}
