using Bosch.JaSemNetoperek.DALCore.Configurations;
using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bosch.JaSemNetoperek.DALCore
{
    public class MyContext : DbContext
    {
        
        public DbSet<Station> Stations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<MotorBike> MotorBikes { get; set; }

        public DbSet<Airplane> Airplanes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase2;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StationConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new RentalConfiguration());

            #region StringConvention

            StringConvention(modelBuilder);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        private static void StringConvention(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && property.Name.Contains("Name"))
                    {
                        property.SetMaxLength(255);
                    }
                }
            }
        }
    }
}
