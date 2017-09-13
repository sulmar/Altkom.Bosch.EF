using Bosch.JaSemNetoperek.DAL;
using Bosch.JaSemNetoperek.DbServices;
using Bosch.JaSemNetoperek.MockServices;
using Bosch.JaSemNetoperek.Models;
using Bosch.JaSemNetoperek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosh.JaSemNetoperek.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUsersAsyncTest();

            GetsUsersTest();

            SetIsDeletedStatusTest();

            RowVersionTest();

            ConcurencyTest();


            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

            return;

            AddStationTest();

            AddUserTest();

            AddBikeTest();

            AddCarTest();

            AddAirplaneTest();

            AddRentalTest();

            GetVehiclesTest();


            // UpdateTest();



        }


        private static void GetUsersAsyncTest()
        {
            Task.Run(() => GetUsersAsync());
        }

        private static async Task GetUsersAsync()
        {
            using (IUsersService service = new DbUsersService())
            {
                var users = await service.GetAsync();
            }
        }



        private static void GetsUsersTest()
        {
            using (IUsersService service = new DbUsersService())
            {
                var users = service.Get();
            }
        }

        private static void SetIsDeletedStatusTest()
        {
            using (IUsersService service = new DbUsersService())
            {
                service.SetIsDeletedStatus(true);
            }
        }

        private static void RowVersionTest()
        {
            using (IUsersService service1 = new DbUsersService())
            using (IUsersService service2 = new DbUsersService())
            {
                var user1 = service1.Get(1);

                var user2 = service2.Get(1);

                user1.FirstName = "Jan";
                user1.LastName = "Kowalski";

                user2.FirstName = "Ania";
                user2.LastName = "Kowalska";

                service2.Update(user2);


                service1.Update(user1);

                


            }
        }

        private static void ConcurencyTest()
        {
            using (IStationsService service1 = new DbStationsService())
            using (IStationsService service2 = new DbStationsService())
            {
                var station1 = service1.Get(1);

                var station2 = service2.Get(1);

                station1.Name = "Stacja 10";

                station2.Name = "Stacja 22";

                try
                {
                    service2.Update(station2);

                    service1.Update(station1);
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        private static void AddRentalTest()
        {
            using (IUsersService usersService = new DbUsersService())
            using (IStationsService stationsService = new DbStationsService())
            using (IVehiclesService vehiclesService = new DbVehiclesService())
            using (IRentalsService service = new DbRentalsService())
            {
                var rentee = usersService.Get(1);
                var station = stationsService.Get(1);
                var vehicle = vehiclesService.Get(1);

                var rental = new Rental
                {
                    FromDate = DateTime.Now,
                    FromStation = station,
                    Rentee = rentee,
                    Vehicle = vehicle
                };

                service.Add(rental);

            }






        }

        private static void GetVehiclesTest()
        {
            using (IVehiclesService vehiclesService = new DbVehiclesService())
            {
                var cars = vehiclesService.Get<Car>();

                IEnumerable<Vehicle> vehicles = vehiclesService.Get();



                //var cars = vehicles.OfType<Car>();
            }
        }

        private static void AddAirplaneTest()
        {
            Vehicle vehicle = new Airplane
            {
                Name = "Jumbo jet",
                EngineCapacity = 10000,
                EngineType = EngineType.Combustion,
                MaxSpeed = 977,
                Location = new Location { Longitude = 21.45f, Latitude = 51.04f }
            };

            using (IVehiclesService vehiclesService = new DbVehiclesService())
            {
                vehiclesService.Add(vehicle);
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

        private static void UpdateTest()
        {
            Station station;

            // request #1
            using (IStationsService stationsService = new DbStationsService())
            {
                station = stationsService.Get(1);
            }

            station.Capacity = 99;

            // request #2
            using (IStationsService stationsService = new DbStationsService())
            {
                stationsService.Update(station);
            }


        }

        private static void AddStationTest()
        {
            var station = new Station
            {
                Name = "Stacja 1",
                Capacity = 10,
                Location = new Location { Longitude = 21.45f, Latitude = 51.04f }
            };

            using (IStationsService stationsService = new DbStationsService())
            {
                stationsService.Add(station);
            }
        }

        private static void AddUserTest()
        {
            var user = new User
            {
                FirstName = "Kasia",
                LastName = "Sulecka"
            };


            using (IUsersService usersService = new DbUsersService())
            {
                usersService.Add(user);
            }

          







        }
    }
}
