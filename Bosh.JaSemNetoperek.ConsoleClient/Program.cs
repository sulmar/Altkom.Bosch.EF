﻿using Bosch.JaSemNetoperek.DAL;
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
          //  AddUserTest();

            AddRentalTest();

            //AddBikeTest();

            //AddCarTest();

            //AddAirplaneTest();



            //GetVehiclesTest();

            
            // UpdateTest();


          
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

            //var station = new Station
            //{
            //    Name = "Stacja 2",
            //    Capacity = 10,
            //    Location = new Location { Longitude = 21.45f, Latitude = 51.04f }
            //};  

            //using(IStationsService stationsService = new DbStationsService())
            //{
            //    stationsService.Add(station);
            //}  







        }
    }
}
