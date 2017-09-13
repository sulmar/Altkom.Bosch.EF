using System;
using Bosch.JaSemNetoperek.DALCore.Configurations;
using Bosch.JaSemNetoperek.Models;
using Microsoft.EntityFrameworkCore;

namespace Bosch.JaSemNetoperek.DALCore
{
    public class NetoperekContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<MotorBike> MotorBikes { get; set; }

        public DbSet<Airplane> Airplanes { get; set; }

        public DbSet<Car> Cars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NetoperekCoreDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StationConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            SetStringConvention(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetStringConvention(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                Console.WriteLine(entityType.Name);

                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && property.Name.Contains("Name"))
                    {
                        property.SetMaxLength(255);
                    }

                    Console.WriteLine(property.Name);


                }

            }
        }
    }
}
