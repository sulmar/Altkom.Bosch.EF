﻿// <auto-generated />
using Bosch.JaSemNetoperek.DALCore;
using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Bosch.JaSemNetoperek.DALCore.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Cost");

                    b.Property<DateTime>("FromDate");

                    b.Property<int?>("FromStationStationId");

                    b.Property<int?>("RenteeUserId");

                    b.Property<DateTime?>("ToDate");

                    b.Property<int?>("ToStationStationId");

                    b.Property<int?>("VehicleId");

                    b.HasKey("RentalId");

                    b.HasIndex("FromStationStationId");

                    b.HasIndex("RenteeUserId");

                    b.HasIndex("ToStationStationId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Capacity");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("StationId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int?>("StationId");

                    b.Property<string>("VehicleType")
                        .IsRequired();

                    b.HasKey("VehicleId");

                    b.HasIndex("StationId");

                    b.ToTable("Vehicles");

                    b.HasDiscriminator<string>("VehicleType").HasValue("Vehicle");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Airplane", b =>
                {
                    b.HasBaseType("Bosch.JaSemNetoperek.Models.Vehicle");

                    b.Property<float>("EngineCapacity");

                    b.Property<int>("EngineType");

                    b.Property<int>("MaxSpeed");

                    b.ToTable("Airplane");

                    b.HasDiscriminator().HasValue("A");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Bike", b =>
                {
                    b.HasBaseType("Bosch.JaSemNetoperek.Models.Vehicle");

                    b.Property<bool>("HasBidon");

                    b.ToTable("Bike");

                    b.HasDiscriminator().HasValue("B");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Car", b =>
                {
                    b.HasBaseType("Bosch.JaSemNetoperek.Models.Vehicle");

                    b.Property<float>("EngineCapacity")
                        .HasColumnName("Car_EngineCapacity");

                    b.Property<int>("EngineType")
                        .HasColumnName("Car_EngineType");

                    b.Property<int>("MaxSpeed")
                        .HasColumnName("Car_MaxSpeed");

                    b.ToTable("Car");

                    b.HasDiscriminator().HasValue("C");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.MotorBike", b =>
                {
                    b.HasBaseType("Bosch.JaSemNetoperek.Models.Vehicle");

                    b.Property<float>("EngineCapacity")
                        .HasColumnName("MotorBike_EngineCapacity");

                    b.Property<int>("EngineType")
                        .HasColumnName("MotorBike_EngineType");

                    b.Property<int>("MaxSpeed")
                        .HasColumnName("MotorBike_MaxSpeed");

                    b.ToTable("MotorBike");

                    b.HasDiscriminator().HasValue("M");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Rental", b =>
                {
                    b.HasOne("Bosch.JaSemNetoperek.Models.Station", "FromStation")
                        .WithMany()
                        .HasForeignKey("FromStationStationId");

                    b.HasOne("Bosch.JaSemNetoperek.Models.User", "Rentee")
                        .WithMany()
                        .HasForeignKey("RenteeUserId");

                    b.HasOne("Bosch.JaSemNetoperek.Models.Station", "ToStation")
                        .WithMany()
                        .HasForeignKey("ToStationStationId");

                    b.HasOne("Bosch.JaSemNetoperek.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Station", b =>
                {
                    b.OwnsOne("Bosch.JaSemNetoperek.Models.Location", "Location", b1 =>
                        {
                            b1.Property<int>("StationId");

                            b1.Property<float>("Latitude");

                            b1.Property<float>("Longitude");

                            b1.ToTable("Stations");

                            b1.HasOne("Bosch.JaSemNetoperek.Models.Station")
                                .WithOne("Location")
                                .HasForeignKey("Bosch.JaSemNetoperek.Models.Location", "StationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Bosch.JaSemNetoperek.Models.Vehicle", b =>
                {
                    b.HasOne("Bosch.JaSemNetoperek.Models.Station", "Station")
                        .WithMany("Vehicles")
                        .HasForeignKey("StationId");

                    b.OwnsOne("Bosch.JaSemNetoperek.Models.Location", "Location", b1 =>
                        {
                            b1.Property<int?>("VehicleId");

                            b1.Property<float>("Latitude");

                            b1.Property<float>("Longitude");

                            b1.ToTable("Vehicles");

                            b1.HasOne("Bosch.JaSemNetoperek.Models.Vehicle")
                                .WithOne("Location")
                                .HasForeignKey("Bosch.JaSemNetoperek.Models.Location", "VehicleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
