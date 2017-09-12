using Bosch.JaSemNetoperek.DbCoreServices;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System;

namespace Bosch.JaSemNetoperek.ConsoleCoreClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AddRentalTest();

            GetUsersTest();

            AddUserTest();


            AddCarTest();

            AddBikeTest();

           
            AddStationTest();

           

        }

        private static void AddRentalTest()
        {
            throw new NotImplementedException();
        }

        private static void GetUsersTest()
        {
            using (IUsersService usersService = new DbUsersService())
            {
                var users = usersService.Get();
            }
        }

        private static void AddBikeTest()
        {
            var vehicle = new Bike
            {
                Name = "Romet",
                Location = new Location { Latitude = 51.2f, Longitude = 21.03f },
                HasBidon = true,

            };

            using (IVehiclesService vehiclesService = new DbVehiclesService())
            {
                vehiclesService.Add(vehicle);
            }
        }

        private static void AddCarTest()
        {
            var vehicle = new Car
            {
                Name = "Toyota",
                EngineCapacity = 1800,
                MaxSpeed = 240,
                Location = new Location { Latitude = 51.2f, Longitude = 21.03f },
            };

            using (IVehiclesService vehiclesService = new DbVehiclesService())
            {
                vehiclesService.Add(vehicle);
            }
        }

        private static void AddUserTest()
        {
            var user = new User
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            };


            using (IUsersService usersService = new DbUsersService())
            {
                usersService.Add(user);
            }
        }

        private static void AddStationTest()
        {
            var station = new Station
            {
                Name = "Stacja 2",
                Capacity = 10,
                Location = new Location { Longitude = 21.45f, Latitude = 51.04f }
            };

            using (IStationsService stationsService = new DbStationsService())
            {
                stationsService.Add(station);
            }
        }
    }
}
