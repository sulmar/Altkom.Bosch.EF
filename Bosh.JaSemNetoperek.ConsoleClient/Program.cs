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

            AddUserTest();
        }

        private static void AddUserTest()
        {
            var user = new User
            {
                FirstName = "Bartek",
                LastName = "Sulecki"
            };





            IUsersService usersService = new DbUsersService();

            usersService.Add(user);







        }
    }
}
