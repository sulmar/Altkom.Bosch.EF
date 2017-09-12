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

            AddUserTest();
        }

        private static void AddUserTest()
        {
            var user = new User
            {
                FirstName = "Kasia",
                LastName = "Sulecka"
            };


            //using (IUsersService usersService = new DbUsersService())
            //{
            //    usersService.Add(user);
            //}

            var station = new Station
            {
                Name = "Stacja 2",
                Capacity = 10,
                Location = new Location { Longitude = 21.45f, Latitude = 51.04f }
            };  

            using(IStationsService stationsService = new DbStationsService())
            {
                stationsService.Add(station);
            }  







        }
    }
}
