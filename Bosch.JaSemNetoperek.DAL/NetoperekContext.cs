using Bosch.JaSemNetoperek.DAL.Configurations;
using Bosch.JaSemNetoperek.DAL.Conventions;
using Bosch.JaSemNetoperek.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.JaSemNetoperek.DAL
{
    public class NetoperekContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rental> Rentals { get; set; }


        public NetoperekContext()
            : base("NetoperekConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // ustawiamy klucz podstawowy
            //modelBuilder.Entity<User>()
            //    .HasKey(p => p.UserId);

            //modelBuilder.Entity<User>().Property(p => p.FirstName)
            //    .HasMaxLength(50)
            //    .IsRequired();

            //modelBuilder.Entity<User>().Property(p => p.LastName)
            //    .HasMaxLength(50)
            //    .IsRequired();


            modelBuilder.Configurations
                .Add(new UserConfiguration())
                .Add(new StationConfiguration())
                .Add(new RentalConfiguration())
                .Add(new VehicleConfiguration());


            // TPT
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Airplane>().ToTable("Airplanes");
            modelBuilder.Entity<Bike>().ToTable("Bikes");
            modelBuilder.Entity<MotorBike>().ToTable("MotorBikes");

            // TPC

            //modelBuilder.Entity<Car>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Cars");
            //});

            //modelBuilder.Entity<Airplane>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Airplanes");
            //});

            //modelBuilder.Entity<Bike>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Bikes");
            //});

            //modelBuilder.Entity<MotorBike>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("MotorBikes");
            //});



            modelBuilder.Conventions.Add(new DateTime2Convention());

            modelBuilder.Conventions.Add(new StringConvention());

            // domyslny schemat
            // modelBuilder.HasDefaultSchema("sales");

            base.OnModelCreating(modelBuilder);
        }

    }
}
