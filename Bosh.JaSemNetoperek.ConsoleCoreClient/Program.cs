using System;
using Bosch.JaSemNetoperek.DbCoreServices;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;

namespace Bosh.JaSemNetoperek.ConsoleCoreClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AddBikeTest();

            AddCarTest();

            GetUsersTest();

            AddUserTest();
        }

        private static void GetUsersTest()
        {
            using (IUsersService usersService = new DbUsersService())
            {
                var users = usersService.Get();
            }
        }

        private static void AddUserTest()
        {
            var user = new User
            {
                FirstName = "Bartek",
                LastName = "Sulecki",
                CreatedDate = DateTime.Now,
                IsDeleted = true
            };

            using (IUsersService usersService = new DbUsersService())
            {
                usersService.Add(user);
            }
        }

        private static void AddBikeTest()
        {
            Vehicle vehicle = new Bike
            {
                Name = "Romet",
                HasBidon = true,
                Location = new Location { Longitude = 21.55f, Latitude = 51.04f }
            };

            using (IVehiclesService vehiclesService = new DbVehiclesService())
            {
                vehiclesService.Add(vehicle);
            }
        }

        private static void AddCarTest()
        {
            Vehicle vehicle = new Car
            {
                Name = "Alfa",
                EngineCapacity = 2200,
                EngineType = EngineType.Combustion,
                MaxSpeed = 260,
                Location = new Location { Longitude = 21.55f, Latitude = 51.04f }
            };

            using (IVehiclesService vehiclesService = new DbVehiclesService())
            {
                vehiclesService.Add(vehicle);
            }
        }
    }
}
